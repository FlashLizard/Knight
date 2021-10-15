using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet:MonoBehaviour
{
    float _speed;
    int _demage,_id;
    Vector2 _direction;
    [SerializeField]
    Rigidbody2D rb;

    public Vector2 Direction { get => _direction; set => _direction = value; }
    public int Demage { get => _demage; set => _demage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public int Id { get => _id; set => _id = value; }

    public Bullet(int id,int demage,float speed,Vector2 direction,Vector2 position)
    {
        transform.position = position;
        this.Id = id;
        this.Demage = demage;
        this.Speed = speed;
        this.Direction = direction;
    }

    void Fly()
    {

    }
}
