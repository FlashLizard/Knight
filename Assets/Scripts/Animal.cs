using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour,IGetHurtable
{
    protected int _health;
    [SerializeField]
    float _speed;
    Rigidbody2D _rb;
    Animator _anim;
    public int Health { get => _health; set => _health = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Anim { get => _anim; set => _anim = value; }

    protected void Init()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }
    public abstract void Dead();
    public abstract void GetHurt(int demage);
    //public virtual void TurnFace()
    //{

    //}
    public virtual void Move(float toX,float toY)
    {
        if (toX > 0) Rb.transform.localScale = new Vector3(1, 1, 1);
        if (toX < 0) Rb.transform.localScale = new Vector3(-1, 1, 1);
        Data.Move(Rb,toX*Speed,toY*Speed);
    }

}
