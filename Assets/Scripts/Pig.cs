using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    bool _attacking, _filling;
    float _attackSpeed, _interval=1;
    int _demage;
    [SerializeField]
    LayerMask player;

    public bool Attacking { get => _attacking; set => _attacking = value; }
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public int Demage { get => _demage; set => _demage = value; }
    public float Interval { get => _interval; set => _interval = value; }
    public bool Filling { get => _filling; set => _filling = value; }

    private void FixedUpdate()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("running", Mathf.Sqrt(x * x + y * y));
        if(Physics2D.OverlapCircle(transform.position,0.3f,player)&&Attacking&&!Filling)
        {
            Data.Player.GetComponent<IGetHurtable>().GetHurt(Demage);
            Filling = true;
            Invoke("FillFinish", Interval);
        }
    }
    private void Awake()
    {
        base.Init();
        Id = AnimalId.Pig;
        Speed = 150;
        AttackSpeed = 600;
        Health = 5;
        Demage = 3;
    }
    private void Start()
    {
        Hung();
    }

    public override void Dead()
    {
        BeforeDead();
        Corpse.Create(this.Id,gameObject.transform.position);
        Data.Reward(transform.position, Data.RanInt(2), Data.RanInt(3),1);
        Destroy(gameObject);
    }
    public override void Move(float toX, float toY)
    {
        int direction = transform.position.x < Data.Player.transform.position.x ? 1 : -1;
        Rb.transform.localScale = new Vector3(direction, 1, 1);
        Data.Move(Rb,toX,toY);
    }
    public void Move(Vector3 velocity)
    {
        Move(velocity.x, velocity.y);
    }

    private void Attack()
    {
        Attacking = true;
        Move(AttackSpeed * Data.ToPlayer(transform.position));
        Invoke("Hung", Random.Range(1f, 2f));
    }

    private void Hung()
    {
        Attacking = false;
        float interval = Random.Range(1f, 2f);
        Vector3 velocity;
        if (Random.value > 0.9)
        {
            velocity = new Vector3(Random.value - 0.5f, Random.value - 0.5f).normalized;
        }
        else
        {
            velocity = Data.ToPlayer(transform.position);
        }
        Move(Speed*velocity);
        if (Random.value > 0.5) Invoke("Hung",interval);
        else Invoke("Attack", interval);
    }
    void FillFinish()
    {
        Filling = false;
    }
}
