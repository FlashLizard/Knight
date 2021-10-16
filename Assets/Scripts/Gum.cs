using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : EquipData
{
    private BulletId _bulletId;
    private int _speed;
    public Gum(EquipId id, string name, EquipQuality quality, int demage, int depletion, float interval,BulletId bulletId,int speed) :
        base(id,name, EquipType.Gum, quality, demage, depletion,interval)
    {
        this.BulletId = bulletId;
        this.Speed = speed;
    }

    public BulletId BulletId { get => _bulletId; set => _bulletId = value; }
    public int Speed { get => _speed; set => _speed = value; }

    public override void Attack(GameObject Player)
    {
        Bullet.Create(BulletId,this.Demage,this.Speed, Player.GetComponent<Player>().ToMouse, Player.transform.position);
    }
}
