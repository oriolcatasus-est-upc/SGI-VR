using TMPro;
using UnityEngine;

public class TreasuresText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    TreasureManager treasureManager;

    private void Update()
    {
        var total = treasureManager.TotalTreasures;
        var picked = treasureManager.PickedTreasures;
        text.text = $"Treasures: {picked}/{total}";
    }
}
