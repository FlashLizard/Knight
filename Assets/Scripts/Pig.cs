using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    bool _running;

    public bool Running { get => _running; set => _running = value; }

    private void Start()
    {
        base.Init();
        Speed = 100;
        Health = 5;
        Hung();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void GetHurt(int demage)
    {
        this.Health -= demage;
        if (this.Health < 0) Dead();
    }

    public override void Move(float toX, float toY)
    {
        int direction = 1;
        direction = transform.position.x < Data.GetPlayer().transform.position.x ? 1 : -1;
        Rb.transform.localScale = new Vector3(direction, 1, 1);
        Data.Move(Rb,toX*Speed,toY*Speed);
    }

    private void Attack()
    {

    }

    private void Hung()
    {
        Running = true;
        float interval = Random.Range(1f, 2f);
        Vector2 velocity;
        if (Random.value > 0.8)
        {
            velocity = Data.Normalize(new Vector2(Random.value - 0.5f, Random.value - 0.5f));
        }
        else
        {
            velocity = Data.ToPlayer(transform.position);
        }
        Move(velocity.x,velocity.y);
        //if (Random.value > 0.2) 
        Invoke("Hung",interval);
        //Invoke("Attack", interval);
        Running = false;
    }
}
