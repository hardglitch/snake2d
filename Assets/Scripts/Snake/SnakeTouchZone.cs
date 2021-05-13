using System;
using UnityEngine;

namespace Snake
{
    public class SnakeTouchZone : MonoBehaviour
    {
        [SerializeField] private Controllers snakeControllers;

        private void OnMouseDrag()
        {
            snakeControllers.OnMouseDrag();
        }
    }
}
