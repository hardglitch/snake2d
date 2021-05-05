using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text bonusText;
    [SerializeField] private Vector2Int bonusRange = new Vector2Int(1, 99);
    public int BonusSize { get; private set; }

    private void Start()
    {
        BonusSize = Random.Range(bonusRange.x, bonusRange.y);
        bonusText.text = BonusSize.ToString();
    }
}
