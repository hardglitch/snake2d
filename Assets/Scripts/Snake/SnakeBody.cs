using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(AudioSource))]
    public class SnakeBody : MonoBehaviour
    {
        [SerializeField] private Segment segmentPrefab;
        [SerializeField] private float speed = 1f;

        private readonly List<Segment> _segments = new List<Segment>();
        private SnakeHead _snakeHead;
        private Controllers _controllers;
        private AudioSource _audioSource;
        private Animator _animator;
        private readonly int _deathAnim = Animator.StringToHash("Death");
        public bool DeathState { get; set; }

        public int BodySize => _segments.Count;

        private void Start()
        {
            _snakeHead = GetComponentInChildren<SnakeHead>();
            _controllers = GetComponentInChildren<Controllers>();
            _audioSource = GetComponent<AudioSource>();
            _animator = _snakeHead.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void AddSegment()
        {
            var segment = Instantiate(segmentPrefab, transform);
            _segments.Add(segment);
        }

        public void RemoveSegment()
        {
            if (_segments.Count <= 0) return;
            Destroy(_segments[0].gameObject);
            _segments.RemoveAt(0);
        }

        private void Move()
        {
            var direction = _controllers.GetDirectionToTouch();
            const float sinusY = 0.5f; // 30..150 Degrees Diapason
            if (direction.y < sinusY) direction.y = sinusY; 
            _snakeHead.transform.up = direction;

            var snakeHeadPrePos = _snakeHead.transform.position;
            var newPos = snakeHeadPrePos + _snakeHead.transform.up * speed * Time.fixedDeltaTime;
            _snakeHead.MoveTo(newPos);

            if (_segments is null) return;
            var segmentPos = snakeHeadPrePos;
            foreach (var segment in _segments)
            {
                var segmentPrePos = segment.transform.position;
                segmentPos.y += sinusY;
                segment.transform.position = Vector2.Lerp(
                    segmentPrePos, segmentPos, speed * Time.fixedDeltaTime);
                segmentPos = segmentPrePos;
            }
        }

        public void Death()
        {
            if (DeathState) return;
            _animator.SetTrigger(_deathAnim);
            _audioSource.Play();
            DeathState = true;
        }
    }
}
