using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMine : Destruction
{
    void Start()
    {
        Init(DestructionId.MagicMine,20);
    }
    public override void Dead()
    {
        Data.Reward(transform.position, 12, 0,2);
        Corpse.Create(Id.ToString(),transform.position);
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("MagicMine", position);
    }
}
