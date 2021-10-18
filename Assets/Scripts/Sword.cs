using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EquipData
{
    public Sword(EquipId id,string name, EquipQuality quality, int demage, int depletion,float interval,Atk attack) :
        base(id,name, EquipType.Sword, quality, demage, depletion,interval,attack)
    {

    }
}
