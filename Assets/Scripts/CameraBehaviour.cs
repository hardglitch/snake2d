using Snake;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private SnakeHead snakeHead;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float snakePosShift = 2f;

    private void FixedUpdate()
    {
        var snakeHeadPos = snakeHead.transform.position;
        snakeHeadPos.x = transform.position.x;
        snakeHeadPos.y += snakePosShift;
        snakeHeadPos.z = transform.position.z;
        transform.position = Vector3.Lerp(
            transform.position, snakeHeadPos, speed * Time.fixedDeltaTime);
    }
}