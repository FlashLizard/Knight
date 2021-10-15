using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet:MonoBehaviour
{
    float _speed;
    int _demage;
    //BulletId _id;
    //EquipId _gumId;
    //Vector2 _direction;
    [SerializeField]
    Rigidbody2D rb;
    GameObject parent;
    CircleCollider2D coll;

    //public Vector2 Direction { get => _direction; set => _direction = value; }
    public int Demage { get => _demage; set => _demage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    //public BulletId Id { get => Id; set => Id = value; }
    //public EquipId GumId { get => _gumId; set => _gumId = value; }

    public void Fire(EquipId gumId,Vector2 direction,Vector2 position)
    {
        this.Demage = Data.equipments[(int)gumId-1].Demage;
        this.Speed = ((Gum)Data.equipments[(int)gumId - 1]).Speed;
        BulletId id = ((Gum)Data.equipments[(int)gumId - 1]).BulletId;
        rb.velocity = Speed*direction;
        gameObject.transform.position = position;
        Data.FreshImage(gameObject, Data.GetImage(id));
        coll = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        coll.radius = Data.bullets[(int)id].Radius;
        //transform.rotation = ;
    }
}
