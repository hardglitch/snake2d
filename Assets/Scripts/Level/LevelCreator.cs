using ADS;
using Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    [RequireComponent(typeof(ADSettings))]
    public class LevelCreator : MonoBehaviour
    {
        [Header("Prefabs")][Space]
        [SerializeField] private Transform container;
        [SerializeField] private Empty emptyPrefab;
        [SerializeField] private Block blockPrefab;
        [SerializeField] private Wall wallPrefab;
        [SerializeField] private Bonus bonusPrefab;

        [Space] [Header("Percentage")]
        [Range(0, 100)]
        [SerializeField] private int emptySpaceChance = 40;
        private const int EmptySpaceConst = 0;
    
        [Range(0, 100)]
        [SerializeField] private int blockSpawnChance = 30;
        private const int BlockConst = 1;

        [Range(0, 100)]
        [SerializeField] private int wallSpawnChance = 20;
        private const int WallConst = 2;

        [Range(0, 100)]
        [SerializeField] private int bonusSpawnChance = 10;
        private const int BonusConst = 3;

        [SerializeField] private int levelSize = 50;

        private SpawnPoint[] _spawnPoints;
        private const int DistanceBetweenLines = 1;

        private ADSettings _adSettings;

        private void Start()
        {
            _adSettings = GetComponent<ADSettings>();
            if (ReloadCounter.Value == 0 || ReloadCounter.Value % 5 == 0)
                _adSettings.ShowInterstitial();

            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
            for (var i = 0; i < levelSize; i++)
            {
                GenerateLine();
                MoveSpawner();
            }
            
            _adSettings.ShowBanner();
        }

        private void GenerateLine()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                CreateElement(spawnPoint.transform.position);
            }
        }

        private void CreateElement(Vector3 spawnPoint)
        {
            GameObject createdElement;
            var randomChance = Random.Range(0, 100);
        
            if (randomChance <= emptySpaceChance)
                createdElement = emptyPrefab.gameObject;
            else if (randomChance > emptySpaceChance &&
                     randomChance <= blockSpawnChance + emptySpaceChance &&
                     GetLeftElementType(spawnPoint) != WallConst &&
                     GetBottomElementType(spawnPoint) != BlockConst)
                createdElement = blockPrefab.gameObject;
            else
            if (randomChance > blockSpawnChance + emptySpaceChance &&
                randomChance <= blockSpawnChance + emptySpaceChance + wallSpawnChance)
                createdElement = wallPrefab.gameObject;
            else
            if (randomChance < 100 - bonusSpawnChance)
                createdElement = bonusPrefab.gameObject;
            else
                createdElement = emptyPrefab.gameObject;

            Instantiate(createdElement, spawnPoint, Quaternion.identity, container);
        }

        private int GetLeftElementType(Vector3 spawnPoint)
        {
            var leftHit = Physics2D.Raycast(spawnPoint, Vector2.left, 1);
            if (!leftHit) return EmptySpaceConst;
        
            var go = leftHit.collider.gameObject;
        
            if (go.TryGetComponent(out Wall _)) return WallConst;
            if (go.TryGetComponent(out Block _)) return BlockConst;
            if (go.TryGetComponent(out Bonus _)) return BonusConst;

            return EmptySpaceConst;
        }

        private int GetBottomElementType(Vector3 spawnPoint)
        {
            var bottomHit1 = Physics2D.Raycast(spawnPoint, Vector2.down, 1);

            var insideShift = wallPrefab.transform.localScale.x / 2f;
            var wallPoint = new Vector2(spawnPoint.x + insideShift, spawnPoint.y);
            var bottomHit2 = Physics2D.Raycast(wallPoint, Vector2.down, 1);
        
            var go1 = bottomHit1 ? bottomHit1.collider.gameObject : null;
            var go2 = bottomHit2 ? bottomHit2.collider.gameObject : null;

            return go2 switch
            {
                { } when go1 is { } && (go1.TryGetComponent(out Wall _) || go2.TryGetComponent(out Wall _)) => WallConst,
                { } when go1 is { } && (go1.TryGetComponent(out Block _) || go2.TryGetComponent(out Block _)) => BlockConst,
                { } when go1 is { } && (go1.TryGetComponent(out Bonus _) || go2.TryGetComponent(out Bonus _)) => BonusConst,
                _ => EmptySpaceConst
            };
        }


        private void MoveSpawner()
        {
            var spawnerPos = transform.position;
            transform.position = new Vector3(spawnerPos.x, spawnerPos.y + DistanceBetweenLines, spawnerPos.z);
        }
    }
}
