using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public int TotalTreasures { get; private set; } = 0;
    public int PickedTreasures { get; private set; } = 0;

    private void Start()
    {
        TotalTreasures = transform.childCount;
    }

    public void PickTreasure()
    {
        ++PickedTreasures;
    }
}
