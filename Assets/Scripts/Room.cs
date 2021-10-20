using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] doors= new GameObject[4];
    [SerializeField]
    protected GameObject[] invisibleDoors=new GameObject[4];
    public float X
    {
        get => transform.position.x;
    }
    public float Y
    {
        get => transform.position.y;
    }

    public void OpenDoor(int direction)
    {
        doors[direction].SetActive(true);
        invisibleDoors[direction].SetActive(false);
    }
    public List<int> RemainDoors()
    {
        List<int> rest=new List<int>();
        for (int i = 0; i < 4; i++)
        {
            if (!Data.HaveRoom(i,this)) rest.Add(i);
        }
        return rest;
    }
}
