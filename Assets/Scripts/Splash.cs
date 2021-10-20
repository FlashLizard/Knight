using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    //float _speed;
    string _from;
    int _demage;
    //BulletId _id;
    //EquipId _gumId;
    //Vector2 _direction;

    //public Vector2 Direction { get => _direction; set => _direction = value; }
    public int Demage { get => _demage; set => _demage = value; }
    public string From { get => _from; set => _from = value; }

    //public float Speed { get => _speed; set => _speed = value; }
    //public BulletId Id { get => Id; set => Id = value; }
    //public EquipId GumId { get => _gumId; set => _gumId = value; }
    private void Start()
    {
        Invoke("Dead", 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Data.CanAttack(From, collision.gameObject.tag)||collision.tag=="Bullet")
        {
            collision.GetComponent<IGetHurtable>().GetHurt(Demage);
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    public static void Create(int demage, float radius, Vector3 direction, Vector3 position, string from)
    {
        GameObject newSplash = Data.Produce("Splash",position+radius*direction,Data.Player);
        Splash splash = newSplash.GetComponent<Splash>();
        splash.Demage = demage;
        //position -= 0.2f*direction;
        //coll.transform.position = Data.TwoToThree(position);
        splash.From = from;
        newSplash.transform.right = direction;
        newSplash.transform.localScale = new Vector3(radius, radius, 0);
    }
}
