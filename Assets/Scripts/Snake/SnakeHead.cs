using TMPro;
using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SnakeHead : MonoBehaviour
    {
        [SerializeField] private TMP_Text bodySizeText;
        private Rigidbody2D _rigidbody2D;
        private SnakeBody _snakeBody;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _snakeBody = GetComponentInParent<SnakeBody>();
        }

        public void MoveTo(Vector3 position)
        {
            _rigidbody2D.MovePosition(position);
            bodySizeText.text = _snakeBody.BodySize.ToString();
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Block block))
            {
                block.Damage(ref _snakeBody);
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
