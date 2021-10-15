using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipId
{
    Null,
    OrignalPistol,
    BigSword

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

}
struct BulletData
{
    public string name;
    public float radius;
    public BulletData(string name,float radius)
    {
        this.name = name;
        this.radius = radius;
    }
}
struct EquipData
{
    public string name;
    public EquipType type;
    public EquipQuality quality;
    public BulletId bulletId;
    public float interval;
    public EquipData(string name, EquipType type, EquipQuality quality, BulletId bulletId,float interval)
    {
        this.name = name;
        this.type = type;
        this.quality = quality;
        this.bulletId = bulletId;
        this.interval = interval;
    }
}
static class Data
{
    public static EquipData[] equipments = 
        { new EquipData("OrignalPistol",EquipType.Gum,EquipQuality.White,BulletId.Normal,0.5f),
    new EquipData("BigSword",EquipType.Sword,EquipQuality.White,BulletId.Normal,0.8f) };
    public static BulletData[] bullets =
         { new BulletData("Normal",0.2f) };
    public static string GetImage(EquipId id)
    {
        return @"Equipments/" + equipments[(int)id-1].name;
    }
    public static string GetName(EquipId id)
    {
        return equipments[(int)id-1].name;
    }
    public static string GetImage(BulletId id)
    {
        return @"Bullets/" + bullets[(int)id - 1].name;
    }
    public static void FreshImage(GameObject gameObject,string image)
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>(image);
    }
}