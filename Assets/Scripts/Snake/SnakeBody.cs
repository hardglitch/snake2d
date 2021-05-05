using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeBody : MonoBehaviour
    {
        [SerializeField] private Segment segmentPrefab;
        [SerializeField] private float bodySpringiness = 10f;
        [SerializeField] private float speed = 1f;
        private readonly List<Segment> _segments = new List<Segment>();
        private float _segmentDiameter = 0.5f;
        private SnakeHead _snakeHead;

        private const float MinX = -2.5f, MaxX = 2.5f;

        public int BodySize => _segments.Count;

        private void Awake()
        {
            _snakeHead = GetComponentInChildren<SnakeHead>();
            AddSegment();
            AddSegment();
            AddSegment();
            _segmentDiameter = _segments[0].transform.localScale.y;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void AddSegment()
        {
            _segments.Add(Instantiate(segmentPrefab, transform));
        }

        public void RemoveSegment()
        {
            Destroy(_segments[0].gameObject);
            _segments.RemoveAt(0);
        }

        private void Move()
        {
            var snakeHeadPrePos = _snakeHead.transform.position;
            var newPos = snakeHeadPrePos + transform.up * speed * Time.fixedDeltaTime;
            _snakeHead.transform.position = newPos;
                
            foreach (var segment in _segments)
            {
                var segmentPrePos = segment.transform.position;
                if (snakeHeadPrePos.y - segmentPrePos.y < _segmentDiameter)
                    segmentPrePos.y = snakeHeadPrePos.y - _segmentDiameter;
                segment.transform.position = Vector2.Lerp(
                    segmentPrePos, snakeHeadPrePos, bodySpringiness * Time.fixedDeltaTime);
                _snakeHead.MoveTo(segment.transform.position);
                snakeHeadPrePos = segmentPrePos;
            }
        }
    }
}
