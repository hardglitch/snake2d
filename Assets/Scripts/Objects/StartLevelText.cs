using TMPro;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(TMP_Text))]
    public class StartLevelText : MonoBehaviour
    {
        private TMP_Text _levelText;
        public static int LevelCount { get; set; } = 1;

        private void Start()
        {
            _levelText = GetComponent<TMP_Text>();
            _levelText.text = "LEVEL " + LevelCount;
        }
    }
    
}
