using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWitch : Animal
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

    private void Start()
    {
        base.Init();
        Id = AnimalId.GoblinWitch;
        Equipment = EquipId.GoblinStaff;
        Speed = 150;
        Health = 9;
        Hung();
    }
    public override void Dead()
    {
        Corpse.Create(this.Id, gameObject.transform.position);
        Data.Reward(transform.position, 2, 5);
        Destroy(gameObject);
    }
    public override void GetHurt(int demage)
    {
        this.Health -= demage;
        if (this.Health < 0) Dead();
    }
    public override void Move(float toX, float toY)
    {
        int direction = transform.position.x < Data.GetPlayer().transform.position.x ? 1 : -1;
        Rb.transform.localScale = new Vector3(direction, 1, 1);
        Data.Move(Rb, toX, toY);
    }
    public void Move(Vector2 velocity)
    {
        Move(velocity.x, velocity.y);
    }

    private void Attack()
    {
        Data.Get(Equipment).Attack(Equipment, tag, hand, Data.ToPlayer(transform.position));
        Invoke("Hung", Random.Range(0.3f, 0.8f));
    }

    private void Hung()
    {
        float interval = Random.Range(0.3f, 0.8f), distance = Data.DisToPlayer(gameObject.transform.position);
        Vector2 velocity;
        if (distance < 2f)
        {
            velocity = Data.Normalize(new Vector2(Random.value - 0.5f, Random.value - 0.5f));
        }
        else if (distance > 3f)
        {
            velocity = -Data.Normalize(new Vector2(Random.value - 0.5f, Random.value - 0.5f));
        }
        else
        {
            velocity = Data.ToPlayer(transform.position);
        }
        Move(Speed * velocity);
        if (Random.value > 0.75) Invoke("Hung", interval);
        else Invoke("Attack", interval);
    }
}
