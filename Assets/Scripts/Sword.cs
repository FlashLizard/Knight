using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EquipData
{
    float _radius;
    public float Radius { get => _radius; set => _radius = value; }
    public Sword(EquipId id,string name, Color quality, int demage, int depletion,float interval,Atk attack,float radius) :
        base(id,name, EquipType.Sword, quality, demage, depletion,interval,attack)
    {
        Radius = radius;
    }
}
