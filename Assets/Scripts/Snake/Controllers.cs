using UnityEngine;

namespace Snake
{
    [RequireComponent(typeof(SnakeHead))]
    public class Controllers : MonoBehaviour
    {
        private SnakeHead _snakeHead;
        private const float MinX = -2.5f, MaxX = 2.5f;
        private float _snakeHeadRadius = 0.5f; 
        private Camera _camera;
        private Vector2 _touchPos;

        private void Start()
        {
            _camera = Camera.main;
            _snakeHead = GetComponent<SnakeHead>();
            _snakeHeadRadius = _snakeHead.transform.localScale.x;
        }

        public void OnMouseDrag()
        {
            _touchPos = Input.GetTouch(0).position;
            
            if (_touchPos == Vector2.zero) return;

            if (_camera is { }) _touchPos = _camera.ScreenToWorldPoint(_touchPos);
            _touchPos.x = Mathf.Clamp(_touchPos.x, MinX + _snakeHeadRadius, MaxX - _snakeHeadRadius);
        }
        
        public Vector2 GetDirectionToTouch()
        {
            var snakeHeadPos = _snakeHead.transform.position;
            return new Vector2(_touchPos.x - snakeHeadPos.x, _touchPos.y - snakeHeadPos.y);
        }
    }
}