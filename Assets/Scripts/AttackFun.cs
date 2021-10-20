using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Atk(EquipId equip,string from, GameObject Hand, Vector3 direction);
public static class AttackFun
{
    public static void Pistol(EquipId equip,string from, GameObject Hand, Vector3 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position, from);
    }
    public static void ShotGum(EquipId equip, string from, GameObject Hand, Vector3 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        for (int i = 0; i < 5; i++)
        {
            Bullet.Create(gum.BulletId, gum.Demage, gum.Speed,Data.RandomPos(direction,0.5f), Hand.transform.position, from);
        }
    }
    public static void TwoPistol(EquipId equip, string from, GameObject Hand, Vector3 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position-0.5f*direction, from);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position+0.5f * direction, from);
    }
    public static void Sword(EquipId equip, string from, GameObject Hand, Vector3 direction)
    {
        Sword sword = (Sword)Data.Get(equip);
        Splash.Create(sword.Demage, sword.Radius, direction, Hand.transform.position, from);
    }
    public static void GoblinStaff(EquipId equip, string from, GameObject Hand, Vector3 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Vector3 OrginalPos = Hand.transform.position;
        //float s=Mathf
        float[] angle={ -30f,30f,0f};
        for (int i = 0; i < 3; i++)
        {
            Vector3 dir = Data.Ratote(direction,angle[i]);
            Vector3 position = OrginalPos + 2 * dir;
            for (int j = 0; j < 2; j++)
            {
                Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, Data.Ratote(dir, angle[j]), position, from);
            }
        }
    }
}
