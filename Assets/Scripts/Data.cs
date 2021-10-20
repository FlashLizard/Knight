using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalId
{
    Player,
    Pig,
    Goblin1,
    GoblinWitch
}
public enum AcquisitionId
{
    Magic,
    Coin

}
public enum DestructionId
{
    Box,
    MagicMine,
    CoinMine
}
public enum ItemId
{
    Equipment,
    BloodBottle,
    MagicBottle,
    Chest,
    NormalChest,
    Goods,
    Portal

}
public enum EquipId
{
    Null,
    OrignalPistol,
    BigSword,
    GoblinGum,
    GoblinStaff,
    HandSword,
    ShotGum, 
    Meat

}
public enum EquipType
{
    Gum,
    Sword
}
public enum BulletId
{
    Normal,
    Red
}
public static class Data
{

    public static float[] dx = { 0, 0, -34, 34 }, dy = { 22, -22, 0, 0 };
    private static GameObject _player,_statusUI,_settingsUI;
    public static GameObject SettingUI
    {
        get
        {
            if (_settingsUI == null)
            {
                return _settingsUI = Data.Produce("Settings", new Vector3(0, 0));
            }
            return _settingsUI;
        }
    }
    public static GameObject Player
    {
        get
        {
            if (_player == null)
            {
                return _player = Data.Produce("Player", new Vector3(0, 0));
            }
            return _player;
        }
    }
    public static GameObject StatusUI
    {
        get
        {
            if (_statusUI == null)
            {
                return _statusUI = Data.Produce("StatusUI", new Vector3(0, 0));
            }
            return _statusUI;
        }
    }
    public static EquipData[] equipments =
        { new Gum(EquipId.OrignalPistol,"OrignalPistol",Color.white,2,0,0.5f,BulletId.Normal,20,AttackFun.Pistol),
    new Sword(EquipId.BigSword,"BigSword",Color.white,3,0,0.8f,AttackFun.Sword,1),
    new Gum(EquipId.GoblinGum,"GoblinGum",Color.green,3,1,0.5f,BulletId.Red,8,AttackFun.TwoPistol),
    new Gum(EquipId.GoblinStaff,"GoblinStaff",Color.green,3,2,0.7f,BulletId.Red,8,AttackFun.GoblinStaff),
    new Sword(EquipId.HandSword,"HandSword",Color.white,1,0,0.3f,AttackFun.Sword,0.5f),
    new Gum(EquipId.ShotGum,"ShotGum",Color.blue,3,2,0.5f,BulletId.Normal,15,AttackFun.ShotGum),
    new Sword(EquipId.Meat,"Meat",Color.blue,2,0,0.4f,AttackFun.Sword,0.3f)};
    public static BulletData[] bullets =
         { new BulletData("Normal",0.2f),
           new BulletData("Red",0.2f)};
    //public static DestructionData[] destructions =
    //      { new DestructionData("Box",2),
    //new DestructionData("Box",2),
    //    new DestructionData("Box",2)};
    public static LayerMask Maze
    {
        get => LayerMask.NameToLayer("Maze");
    }
    public static LayerMask EnemyLayer
    {
        get => LayerMask.NameToLayer("Enemy");
    }
    public static string GetImage(EquipId id)
    {
        return @"Equipments/" + Get(id).Name;
    }
    public static string GetName(EquipId id)
    {
        return Get(id).Name;
    }
    public static string GetImage(BulletId id)
    {
        return @"Bullets/" + Get(id).Name;
    }
    //public static string GetImage(DestructionId id)
    //{
    //    return @"Destructions/" + id.ToString();
    //}
    public static EquipData Get(EquipId id)
    {
        return equipments[(int)id - 1];
    }
    public static BulletData Get(BulletId id)
    {
        return bullets[(int)id];
    }
    //public static DestructionData Get(DestructionId id)
    //{
    //    return destructions[(int)id];
    //}
    public static void FreshImage(GameObject gameObject, string image)
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>(image);
    }
    public static GameObject Produce(string name, Vector3 position)
    {
        return Object.Instantiate(Resources.Load<GameObject>("Prefabs/" + name), position, new Quaternion(0, 0, 0, 1));
    }
    public static GameObject Produce(string name, Vector3 position,GameObject parent)
    {
        GameObject child = Produce(name, position);
        child.transform.parent = parent.transform;
        return child;
    }
    public static Vector3 RandomPos(Vector3 position, float delta)
    {
        return new Vector3(position.x + (0.5f - Random.value) * delta, position.y + (0.5f - Random.value) * delta);
    }
    public static void Move(Rigidbody2D rb, float toX, float toY)
    {
        rb.velocity = new Vector3(toX * Time.fixedDeltaTime, toY * Time.fixedDeltaTime);
    }
    public static void FreshPlayer()
    {
        GameObject.Destroy(Player);
    }
    public static Vector3 ToPlayer(Vector3 position)
    {
        return (Player.transform.position - position).normalized;
    }
    public static void Reward(Vector3 position, int magicNum, int coinNum, float range)
    {
        for (int i = 0; i < magicNum; i++)
        {
            Produce("Magic", RandomPos(position, range));
        }
        for (int i = 0; i < coinNum; i++)
        {
            Produce("Coin", RandomPos(position, range));
        }
    }
    public static float DisToPlayer(Vector3 position)
    {
        return (position - Player.GetComponent<Transform>().position).magnitude;
    }
    public static bool CanAttack(string from, string to)
    {
        if (from == "Player" && (to == "Destruction" || to == "Enemy")) return true;
        if (from == "Enemy" && (to == "Destruction" || to == "Player")) return true;
        return false;
    }
    public static Vector3 Ratote(Vector3 v, float angle)
    {
        angle = angle * Mathf.PI / 180;
        float s = Mathf.Sin(angle), c = Mathf.Cos(angle);
        return new Vector3(v.x * c - v.y * s, v.x * s + v.y * c);
    }
    public static int RanInt(int a)
    {
        return (int)Random.Range(0, a + 0.99f);
    }
    public static int RanInt(int a, int b)
    {
        return a + RanInt(b - a);
    }
    public static bool HaveRoom(int direction,Room room)
    {
        return Physics2D.OverlapCircle(new Vector3(room.X+dx[direction], room.Y+dy[direction]),2f);
    }
    public static EquipId RanEquip()
    {
        EquipId equip;
        do
        {
            equip = (EquipId)RanInt(1, sizeof(EquipId) - 1);
        }
        while (equip == EquipId.HandSword);
        return equip;
    }
}