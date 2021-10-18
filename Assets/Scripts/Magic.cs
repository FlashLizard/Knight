using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Acquisition
{
    private void Start()
    {
        base.Init();
        Id = AcquisitionId.Magic;
    }
    public override void Dead()
    {
        Data.GetPlayer().GetComponent<Player>().Magic+=5;
        Destroy(gameObject);
    }
}
