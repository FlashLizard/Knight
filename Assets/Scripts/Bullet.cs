using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet:MonoBehaviour
{
    //float _speed;
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
    //public float Speed { get => _speed; set => _speed = value; }
    //public BulletId Id { get => Id; set => Id = value; }
    //public EquipId GumId { get => _gumId; set => _gumId = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Destruction")
        {
            //Debug.Log(collision.tag);
            collision.GetComponent<IGetHurtable>().GetHurt(Demage);
            Destroy(gameObject);
        }
    }
    public static void Create(BulletId id,int demage,float speed,Vector2 direction,Vector2 position)
    {
        GameObject newBullet = Object.Instantiate(Resources.Load<GameObject>("Prefabs/BulletSample"),position,new Quaternion(0,0,0,1));
        Bullet bullet = newBullet.GetComponent<Bullet>();
        bullet.Demage = demage;
        newBullet.GetComponent<Rigidbody2D>().velocity = speed*direction;
        Data.FreshImage(newBullet, Data.GetImage(id));
        CircleCollider2D coll = newBullet.AddComponent<CircleCollider2D>() as CircleCollider2D;
        coll.radius = Data.Get(id).Radius;
        coll.isTrigger = true;
    }
}
