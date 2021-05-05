using Snake;
using UnityEngine;

[RequireComponent(typeof(SnakeHead))]
public class Controllers : MonoBehaviour
{
    [SerializeField] private float sideSpeed = 1f;
    private SnakeHead _snakeHead;
    private const float MinX = -2.5f, MaxX = 2.5f;
    private float _snakeHeadRadius; 
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _snakeHead = GetComponent<SnakeHead>();
        _snakeHeadRadius = _snakeHead.transform.localScale.x;
    }

    private void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        if (_camera is { }) mousePos = _camera.ScreenToWorldPoint(mousePos);
        mousePos.x = Mathf.Clamp(mousePos.x, MinX + _snakeHeadRadius, MaxX - _snakeHeadRadius);

        var snakeHeadPos = _snakeHead.transform.position;
        snakeHeadPos.x = mousePos.x;

        _snakeHead.transform.position = Vector3.Lerp(_snakeHead.transform.position, snakeHeadPos, sideSpeed * Time.deltaTime);

    }
}