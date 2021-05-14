using Snake;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Block : MonoBehaviour
    {
        [SerializeField] private TMP_Text blockLegend;
        [SerializeField] private Vector2Int randomRange = new Vector2Int(1,10);
        [SerializeField] private Color[] colors;

        private int _blockStrong;

        
        private void Start()
        {
            var a = 
                _blockStrong = Random.Range(randomRange.x, randomRange.y);
            blockLegend.text = _blockStrong.ToString();

            var blockStrongLevel = randomRange.y / colors.Length;
            var strongLevelColor = _blockStrong / blockStrongLevel;
            if (strongLevelColor >= colors.Length) strongLevelColor = colors.Length - 1;
            GetComponent<SpriteRenderer>().color = colors[strongLevelColor];
        }

        public void Damage(ref SnakeBody snakeBody)
        {
            snakeBody.RemoveSegment();
            if (snakeBody.BodySize < 1)
            {
                Destroy(snakeBody.gameObject);   //TODO: Death Method
                SceneManager.LoadScene(0);
            }
            
            blockLegend.text = (_blockStrong--).ToString();
            if (_blockStrong <= 0) Destroy(gameObject);
        } 
    }
}