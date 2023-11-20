using UnityEngine;

public class NavigationPoint : Selectable
{
    [SerializeField]
    float playerHeight;

    Transform player;

    protected override void Start()
    {
        player = Camera.main.transform.parent;
        base.Start();
    }

    public override void OnPointerClick()
    {
        var x = transform.position.x;
        var y = transform.position.y + playerHeight;
        var z = transform.position.z;
        player.position = new Vector3(x, y, z);
    }
}
