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

    public void Init(DestructionId id, string image)
    {
        DestructionData data = Data.Get(id);
        this.Health = data.Health;
        this.Id = id;
        Data.FreshImage(gameObject, image);
        //coll = GetComponent<Collider2D>();
    }
    public void GetHurt(int demage)
    {
        Health -= demage;
        if (Health <= 0) Dead();
    }
    public abstract void Dead();
}
