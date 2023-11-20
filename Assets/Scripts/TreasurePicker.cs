using System.Collections;
using UnityEngine;

public class TreasurePicker : Selectable
{
    [SerializeField]
    float rotationTop;
    [SerializeField]
    float rotationSpeed;

    TreasureManager treasureManager;
    BoxCollider boxCollider;
    Transform topPart;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    protected override void Start()
    {
        topPart = transform.GetChild(0);
        treasureManager = GetComponentInParent<TreasureManager>(true);
        base.Start();
    }

    public override void OnPointerClick()
    {
        treasureManager.PickTreasure();
        boxCollider.enabled = false;
        StartCoroutine(OpenTop());        
    }

    IEnumerator OpenTop()
    {
        float rotation = 0;
        while (rotation < rotationTop)
        {
            topPart.Rotate(new Vector3(-rotationSpeed, 0, 0));
            rotation += rotationSpeed;
            yield return new WaitForFixedUpdate();
        }
        topPart.localEulerAngles = new Vector3(-rotationTop, 0, 0);
    }
}
