using UnityEngine;

namespace HUD
{
    [RequireComponent(typeof(Animator))]
    public class TimeManagement : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Pressed = Animator.StringToHash("Pressed");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void TimeSpeed()
        {
            Time.timeScale = _animator.GetBool(Pressed) ? 0 : 1;
        }
    }
}
