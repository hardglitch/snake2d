using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADS
{
    public class ReloadCounter : MonoBehaviour
    {
        public static int Value { get; private set; }

        private void Start()
        {
            Value++;
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}
