using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Destruction
{
    void Start()
    {
        Init(DestructionId.Box,Data.GetImage(DestructionId.Box));
    }
    public override void Dead()
    {
        if(Random.value>0.15)
        {
            Data.Reward(transform.position,2,0);
        }
        else if(Random.value>0.15)
        {
            Data.Reward(transform.position, 0, 2);
        }
        Destroy(gameObject);
    }
    public static void Create(Vector2 position)
    {
        GameObject newBox = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BoxSample"), position, new Quaternion(0, 0, 0, 1));
    }
}
