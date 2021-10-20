using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMine : Destruction
{
    void Start()
    {
        Init(DestructionId.CoinMine, 20);
    }
    public override void Dead()
    {
        Data.Reward(transform.position, 0, 12, 2);
        Corpse.Create(Id.ToString(), transform.position);
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("CoinMine", position);
    }
}
