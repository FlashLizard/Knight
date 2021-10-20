using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private List<Room> rooms = new List<Room>();
    private List<string> restRooms=new List<string>();
    private string[] roomType = { "CoinMineRoom", "MagicMineRoom", "ShopRoom" };
    void Start()
    {
        Build();
        //newRoom.transform.parent = grid.transform;
    }

    void Build()
    {
        float x = 0, y = Data.dy[1];
        int n = Data.RanInt(2, 3),cnt=0;
        rooms.Add(Create(0,x, y,"EnemyRoom1"));
        for (int i = 1; i <= n; i++)
        {
            while (true)
            {
                int j = Data.RanInt(3);
                if (!Data.HaveRoom(j,rooms[cnt]))
                {
                    x = x + Data.dx[j];
                    y = y + Data.dy[j];
                    rooms[cnt].OpenDoor(j);
                    if (i == n)
                    {
                        Create(j ^ 1, x, y, "FinalRoom");
                    }
                    else
                    {
                        cnt++;
                        rooms.Add(Create(j ^ 1, x, y, "EnemyRoom1"));
                    }
                    break;
                }
            }
        }
        restRooms.Add(roomType[Data.RanInt(roomType.Length-1)]);
        restRooms.Add("ChestRoom");
        restRooms.Add("EnemyRoom1");
        foreach (var item in restRooms)
        {
            List<int> doors = new List<int>();
            Room nowRoom;
            int direction;
            do
            {
                nowRoom = rooms[Data.RanInt(cnt)];
                doors = nowRoom.RemainDoors();
            }
            while (doors.Count == 0);
            direction = doors[Data.RanInt(doors.Count - 1)];
            nowRoom.OpenDoor(direction);
            Create(direction ^ 1, nowRoom.X + Data.dx[direction], nowRoom.Y + Data.dy[direction], item);
        }
    }
    Room Create(int direction,float x, float y,string name)
    {
        GameObject room = Data.Produce("Rooms/"+name, new Vector3(x, y));
        room.transform.parent = grid.transform;
        room.GetComponent<Room>().OpenDoor(direction);
        return room.GetComponent<Room>();
    }
}
