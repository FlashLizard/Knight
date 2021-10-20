using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : EquipData
{
    private BulletId _bulletId;
    private int _speed, _nums;
    public Gum(EquipId id, string name, Color quality, int demage, int depletion, float interval,BulletId bulletId,int speed,Atk attack) :
        base(id,name, EquipType.Gum, quality, demage, depletion,interval,attack)
    {
        this.BulletId = bulletId;
        this.Speed = speed;
    }

    public BulletId BulletId { get => _bulletId; set => _bulletId = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public int Nums { get => _nums; set => _nums = value; }
}
