using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour,IGetHurtable
{
    private AnimalId _id;
    protected int _health;
    [SerializeField]
    float _speed;
    Rigidbody2D _rb;
    Animator _anim;
    public int Health { get => _health; set => _health = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public AnimalId Id { get => _id; set => _id = value; }

    protected void Init()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void BeforeDead()
    {
        gameObject.transform.parent.GetComponent<EnemyRoom>().EnemyNum--;
    }
    protected void HurtAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("NoHurtAnimation",0.1f);
    }
    protected void NoHurtAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
    public abstract void Dead();
    public virtual void GetHurt(int demage)
    {
        HurtAnimation();
        this.Health -= demage;
        if (this.Health <= 0) Dead();
    }
    public abstract void Move(float toX, float toY);

}
