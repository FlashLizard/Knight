using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{
    List<GameObject> enemys = new List<GameObject>();
    bool _active, _end;
    int _enemyNum;
    public int EnemyNum { get => _enemyNum; set => _enemyNum = value; }
    public bool Active { get => _active; set => _active = value; }
    public bool End { get => _end; set => _end = value; }

    [SerializeField]
    GameObject producePos,allWall;
    private void Start()
    {
        foreach(Transform pos in producePos.transform)
        {
            string name = ((AnimalId)Data.RanInt(1, sizeof(AnimalId) - 1)).ToString();
            Debug.Log(name);
            enemys.Add(Data.Produce(name, pos.position,gameObject));
            EnemyNum++;
            enemys[EnemyNum - 1].GetComponent<Animal>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&!Active)
        {
            Active = true;
            foreach(GameObject enemy in enemys)
            {
                if(enemy!=null) enemy.GetComponent<Animal>().enabled = true;
            }
            allWall.SetActive(true);
        }
    }
    private void Update()
    {
        if (End==true || Active == false ) return;
        if (EnemyNum == 0)
        {
            allWall.SetActive(false);
            NormalChest.Create(transform.position);
            End = true;
        }
    }
}
