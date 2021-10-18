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

}
public enum ItemId
{
    Equipment,
    Blood,
    Magic

}
public enum EquipId
{
    Null,
    OrignalPistol,
    BigSword,
    GoblinGum,
    GoblinStaff

}
public enum EquipType
{
    Gum,
    Sword
}
public enum EquipQuality
{
    White,
    Green,
    Blue

}
public enum BulletId
{
    Normal,
    Red
}
static class Data
{
    public static GameObject player;
    public static EquipData[] equipments =
        { new Gum(EquipId.OrignalPistol,"OrignalPistol",EquipQuality.White,1,2,0.5f,BulletId.Normal,20,AttackFun.Pistol),
    new Sword(EquipId.BigSword,"BigSword",EquipQuality.White,1,0,0.8f,AttackFun.Sword),
    new Gum(EquipId.GoblinGum,"GoblinGum",EquipQuality.White,3,1,0.5f,BulletId.Red,15,AttackFun.TwoPistol),
    new Gum(EquipId.GoblinStaff,"GoblinStaff",EquipQuality.White,3,2,0.7f,BulletId.Red,10,AttackFun.GoblinStaff)};
    public static BulletData[] bullets =
         { new BulletData("Normal",0.2f),
           new BulletData("Red",0.2f)};
    public static DestructionData[] destructions =
          { new DestructionData("Box",2) };
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
    public static string GetImage(DestructionId id)
    {
        return @"Destructions/" + Get(id).Name;
    }
    public static EquipData Get(EquipId id)
    {
        return equipments[(int)id - 1];
    }
    public static BulletData Get(BulletId id)
    {
        return bullets[(int)id];
    }
    public static DestructionData Get(DestructionId id)
    {
        return destructions[(int)id];
    }
    public static void FreshImage(GameObject gameObject, string image)
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>(image);
    }
    public static Vector2 ThreeToTwo(Vector3 orgin)
    {
        return new Vector2(orgin.x, orgin.y);
    }
    public static Vector3 TwoToThree(Vector2 orgin)
    {
        return new Vector3(orgin.x, orgin.y);
    }
    public static Vector2 Normalize(Vector2 orgin)
    {
        return Normalize(new Vector3(orgin.x,orgin.y,0));
    }
    public static Vector2 Normalize(Vector3 orgin)
    {
        orgin.z = 0;
        return ThreeToTwo(Vector3.Normalize(orgin));
    }
    public static GameObject Produce(string name,Vector2 position)
    {
        return Object.Instantiate(Resources.Load<GameObject>("Prefabs/"+name), position, new Quaternion(0, 0, 0, 1));
    }
    public static Vector2 RandomPos(Vector2 position,float delta)
    {
        return new Vector2(position.x + (0.5f - Random.value) * delta, position.y + (0.5f - Random.value)*delta);
    }
    public static void Move(Rigidbody2D rb,float toX,float toY)
    {
        rb.velocity = new Vector2(toX * Time.fixedDeltaTime, toY * Time.fixedDeltaTime);
    }
    public static GameObject FreshPlayer()
    {
        return player = GameObject.Find("Player");
    }
    public static GameObject GetPlayer()
    {
        if (player == null) return FreshPlayer();
        return player;
    }
    public static Vector2 ToPlayer(Vector2 position)
    {
        return Normalize(ThreeToTwo(GetPlayer().transform.position)-position);
    }
    public static void Reward(Vector2 position,int magicNum,int coinNum)
    {
        for(int i=0;i<magicNum;i++)
        {
            Produce("MagicSample",RandomPos(position,1));
        }
        for (int i = 0; i < coinNum; i++)
        {
            Produce("CoinSample", RandomPos(position, 1));
        }
    }
    public static float Distence(Vector2 position1,Vector2 position2)
    {
        position1 -= position2;
        return Mathf.Sqrt(position1.x * position1.x + position1.y * position1.y);
    }
    public static float DisToPlayer(Vector2 position)
    {
        return Distence(position,GetPlayer().GetComponent<Transform>().position);
    }
    public static bool CanAttack(string from,string to)
    {
        if (from == "Player" && (to == "Destruction" || to == "Enemy")) return true;
        if (from == "Enemy" && to == "Player") return true;
        return false;
    }
    public static Vector2 Ratote(Vector2 v,float angle)
    {
        angle = angle * Mathf.PI/180;
        float s = Mathf.Sin(angle), c = Mathf.Cos(angle);
        return new Vector2(v.x * c - v.y * s, v.x * s + v.y * c);
    }
}