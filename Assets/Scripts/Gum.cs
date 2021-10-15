using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : EquipData
{
    private BulletId _bulletId;
    private int _speed;
    public Gum(EquipId id, string name, EquipQuality quality, int demage, float interval,BulletId bulletId,int speed) :
        base(id,name, EquipType.Gum, quality, demage,interval)
    {
        this.BulletId = bulletId;
        this.Speed = speed;
    }

    public BulletId BulletId { get => _bulletId; set => _bulletId = value; }
    public int Speed { get => _speed; set => _speed = value; }

    public override void Attack(GameObject Player)
    {
        GameObject newBullet = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BulletSample"));
        newBullet.GetComponent<Bullet>().Fire(this.Id,Player.GetComponent<Player>().ToMouse,Player.transform.position);
    }
}
