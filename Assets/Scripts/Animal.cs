using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    int _health;
    [SerializeField]
    float _speed;
    Rigidbody2D _rb;
    Animator _anim;
    public int Health { get => _health<0?0:_health; set => _health = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Anim { get => _anim; set => _anim = value; }

    protected void Init()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }
    public void Dead()
    {
        
    }
    public void Move(float toX,float toY)
    {
        if (toX > 0) Rb.transform.localScale = new Vector3(1, 1, 1);
        if (toX < 0) Rb.transform.localScale = new Vector3(-1, 1, 1);
        Rb.velocity = new Vector2(toX * Time.fixedDeltaTime, toY * Time.fixedDeltaTime);
    }

}
