using Objects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    public class SnakeHead : MonoBehaviour
    {
        [SerializeField] private TMP_Text bodySizeText;
        [SerializeField] private EffectOnCollision effectOnCollision;
        [SerializeField] private AudioClip collectSfx;

        private Rigidbody2D _rigidbody2D;
        private SnakeBody _snakeBody;
        private AudioSource _audioSource;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _snakeBody = GetComponentInParent<SnakeBody>();
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void MoveTo(Vector2 position)
        {
            _rigidbody2D.MovePosition(position);
            bodySizeText.text = _snakeBody.BodySize.ToString();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Block block) && !_snakeBody.DeathState)
            {
                var sparkleSpawnPos = transform.position;
                sparkleSpawnPos.y += transform.localScale.y / 2f;
                Instantiate(effectOnCollision, sparkleSpawnPos, Quaternion.identity, transform);
                
                _audioSource.Play();
                
                block.Damage(ref _snakeBody);
                
                _rigidbody2D.AddForce(Vector2.down, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bonus bonus))
            {
                _audioSource.PlayOneShot(collectSfx);
                for (var i = 0; i < bonus.BonusSize; i++)
                {
                    _snakeBody.AddSegment();
                }
                Destroy(bonus.gameObject);
            }

            if (other.TryGetComponent(out Finish _))
            {
                // TODO: Victory
                StartLevelText.LevelCount++;
                SceneManager.LoadScene(0);
            }
        }
    }
}
