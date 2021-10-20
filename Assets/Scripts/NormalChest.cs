using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChest : Item
{
    private void Start()
    {
        this.Id = ItemId.NormalChest;
    }
    public override void Interactive(GameObject user)
    {
        float ran = Random.value;
        if (ran > 0.2)
        {
            Data.Reward(transform.position, Data.RanInt(4), Data.RanInt(6),1);
        }
        else if (0.1 < ran && ran < 0.2)
        {
            BloodBottle.Create(transform.position);
        }
        else
        {
            MagicBottle.Create(transform.position);
        }
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("NormalChest", position);
    }
}
