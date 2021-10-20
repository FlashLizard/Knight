using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin1 : Animal
{
    EquipId _equipment;
    [SerializeField]
    GameObject hand;

    public EquipId Equipment { get => _equipment; set => _equipment = value; }

    private void FixedUpdate()
    {
        float x = Rb.velocity.x, y = Rb.velocity.y;
        Anim.SetFloat("running", Mathf.Sqrt(x * x + y * y));
    }
    private void Awake()
    {
        base.Init();
        Id = AnimalId.Goblin1;
        Equipment = EquipId.GoblinGum;
        Speed = 250;
        Health = 5;
    }
    private void Start()
    {
        Hung();
    }
    public override void Dead()
    {
        BeforeDead();
        Corpse.Create(this.Id, gameObject.transform.position);
        Data.Reward(transform.position, Data.RanInt(2), Data.RanInt(3),1);
        Destroy(gameObject);
    }
    public override void Move(float toX, float toY)
    {
        int direction = transform.position.x < Data.Player.transform.position.x ? 1 : -1;
        Rb.transform.localScale = new Vector3(direction, 1, 1);
        Data.Move(Rb, toX, toY);
    }
    public void Move(Vector3 velocity)
    {
        Move(velocity.x, velocity.y);
    }

    private void Attack()
    {
        Data.Get(Equipment).Attack(Equipment,tag,hand, Data.ToPlayer(transform.position));
        Invoke("Hung", Random.Range(0.3f, 0.8f));
    }

    private void Hung()
    {
        float interval = Random.Range(0.3f, 0.8f),distance = Data.DisToPlayer(gameObject.transform.position);
        Vector3 velocity;
        if (distance<2f)
        {
            velocity = new Vector3(Random.value - 0.5f, Random.value - 0.5f).normalized;
        }
        else if(distance>3f)
        {
            velocity = -new Vector3(Random.value - 0.5f, Random.value - 0.5f).normalized;
        }
        else
        {
            velocity = Data.ToPlayer(transform.position);
        }
        Move(Speed * velocity);
        if (Random.value > 0.25) Invoke("Hung", interval);
        else Invoke("Attack", interval);
    }
}
