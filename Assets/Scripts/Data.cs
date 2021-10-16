using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
static class Data
{
    public static EquipData[] equipments =
        { new Gum(EquipId.OrignalPistol,"OrignalPistol",EquipQuality.White,1,0.5f,BulletId.Normal,20),
    new Sword(EquipId.BigSword,"BigSword",EquipQuality.White,1,0.8f) };
    public static BulletData[] bullets =
         { new BulletData("Normal",0.2f) };
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
}