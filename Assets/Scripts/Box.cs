using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Destruction
{
    void Start()
    {
        Init(DestructionId.Box,5);
    }
    public override void Dead()
    {
        float ran = Random.value;
        if(0.7<ran&&ran<0.83)
        {
            Data.Reward(transform.position,2,0,1);
        }
        else if(0.83<ran&&ran<0.96)
        {
            Data.Reward(transform.position, 0, 2,1);
        }
        else if(ran>0.96)
        {
            BloodBottle.Create(transform.position);
        }
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("Box",position);
    }
}
