using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destruction : MonoBehaviour, IGetHurtable
{
    int _health;
    DestructionId _id;
    //[SerializeField]
    //Collider2D coll;

    public int Health { get => _health; set => _health = value; }
    public DestructionId Id { get => _id; set => _id = value; }

    public void Init(DestructionId id,int health)
    {
        this.Health = health;
        this.Id = id;
        //coll = GetComponent<Collider2D>();
    }
    public virtual void GetHurt(int demage)
    {
        HurtAnimation();
        this.Health -= demage;
        if (this.Health < 0) Dead();
    }
    protected void HurtAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        Invoke("NoHurtAnimation", 0.1f);
    }
    protected void NoHurtAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
    public abstract void Dead();
}
