using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    bool _attacking;
    float _attackSpeed;
    int _demage;

    public bool Attacking { get => _attacking; set => _attacking = value; }
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public int Demage { get => _demage; set => _demage = value; }

    private void FixedUpdate()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("running", Mathf.Sqrt(x * x + y * y));
    }

    private void Start()
    {
        base.Init();
        Id = AnimalId.Pig;
        Speed = 150;
        AttackSpeed = 600;
        Health = 9;
        Demage = 3;
        Hung();
    }

    public override void Dead()
    {
        Corpse.Create(this.Id,gameObject.transform.position);
        Data.Reward(transform.position,2,5);
        Destroy(gameObject);
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
        Data.Move(Rb,toX,toY);
    }
    public void Move(Vector2 velocity)
    {
        Move(velocity.x, velocity.y);
    }

    private void Attack()
    {
        Attacking = true;
        Move(AttackSpeed * Data.ToPlayer(transform.position));
        Invoke("Hung", Random.Range(1f, 2f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Attacking == true)
        {
            collision.GetComponent<IGetHurtable>().GetHurt(Demage);
        }
    }

    private void Hung()
    {
        Attacking = false;
        float interval = Random.Range(1f, 2f);
        Vector2 velocity;
        if (Random.value > 0.9)
        {
            velocity = Data.Normalize(new Vector2(Random.value - 0.5f, Random.value - 0.5f));
        }
        else
        {
            velocity = Data.ToPlayer(transform.position);
        }
        Move(Speed*velocity);
        if (Random.value > 0.75) Invoke("Hung",interval);
        else Invoke("Attack", interval);
    }
}
