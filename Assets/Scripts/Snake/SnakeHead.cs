using TMPro;
using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SnakeHead : MonoBehaviour
    {
        [SerializeField] private TMP_Text bodySizeText;
        [SerializeField] private EffectOnCollision effectOnCollision;

        private Rigidbody2D _rigidbody2D;
        private SnakeBody _snakeBody;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _snakeBody = GetComponentInParent<SnakeBody>();
        }

        public void MoveTo(Vector2 position)
        {
            _rigidbody2D.MovePosition(position);
            bodySizeText.text = _snakeBody.BodySize.ToString();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Block block))
            {
                var sparkleSpawnPos = transform.position;
                sparkleSpawnPos.y += transform.localScale.y;
                Instantiate(effectOnCollision, sparkleSpawnPos, Quaternion.identity, transform);
                block.Damage(ref _snakeBody);
                _rigidbody2D.AddForce(Vector2.down, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bonus bonus))
            {
                for (var i = 0; i < bonus.BonusSize; i++)
                {
                    _snakeBody.AddSegment();
                }
                Destroy(bonus.gameObject);
            }
        }
    }
}
