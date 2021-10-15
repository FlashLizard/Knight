using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EquipData
{
    public Sword(EquipId id,string name, EquipQuality quality, int demage,float interval) :
        base(id,name, EquipType.Sword, quality, demage,interval)
    {
    }
    public override void Attack(GameObject Player)
    {

    }
}
