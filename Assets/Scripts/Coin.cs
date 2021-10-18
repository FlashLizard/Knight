using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Acquisition
{
    private void Start()
    {
        base.Init();
        Id = AcquisitionId.Coin;
    }
    public override void Dead()
    {
        Data.GetPlayer().GetComponent<Player>().Coins ++;
        Destroy(gameObject);
    }
}
