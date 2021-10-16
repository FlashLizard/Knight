using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Acquisition
{
    public override void Dead()
    {
        player.GetComponent<Player>().Magic++;
        Destroy(gameObject);
    }
}
