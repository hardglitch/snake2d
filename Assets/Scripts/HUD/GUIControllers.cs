using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD
{
    public class GUIControllers : MonoBehaviour
    {
        private AudioSource _audioSource;
        private Animator _animator;
        private static readonly int Pressed = Animator.StringToHash("Pressed");
        private bool _isSettings;

        private void Start()
        {
            _isSettings = false;
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }
    
        public void OnSettingsScreen()
        {
            _isSettings = !_isSettings;
            _animator.SetBool(Pressed, _isSettings);
            _audioSource.Play();
            if (Time.timeScale == 0) Time.timeScale = 1;
        }

        public void Quit()
        {
            _audioSource.Play();
            Application.Quit();
        }

        public void ReloadLevel()
        {
            Time.timeScale = 1;
            _audioSource.Play();
            SceneManager.LoadScene(0);
        }
    }
}