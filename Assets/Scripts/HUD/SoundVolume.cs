using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace HUD
{
    public class SoundVolume : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        private Slider _slider;
        private const string Volume = "Volume";

        private void Start()
        {
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            audioMixer.SetFloat(Volume, -80 * (1 - _slider.value/_slider.maxValue));
        }
    }
}
