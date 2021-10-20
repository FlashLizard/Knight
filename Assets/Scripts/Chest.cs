using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Item
{
    private void Start()
    {
        this.Id = ItemId.Chest;
    }
    public override void Interactive(GameObject user)
    {
        PickEquip.Create(Data.RanEquip(), transform.position);
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("Chest", position);
    }
}
