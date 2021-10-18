using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Atk(EquipId equip,string from, GameObject Hand, Vector2 direction);
public static class AttackFun
{
    public static void Pistol(EquipId equip,string from, GameObject Hand, Vector2 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position, from);
    }
    public static void TwoPistol(EquipId equip, string from, GameObject Hand, Vector2 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position-Data.TwoToThree(0.5f*direction), from);
        Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, direction, Hand.transform.position+Data.TwoToThree(0.5f * direction), from);
    }
    public static void Sword(EquipId equip, string from, GameObject Hand, Vector2 direction)
    {
        EquipData sword = Data.Get(equip);
        Splash.Create(sword.Demage, 1f, direction, Hand.transform.position, from);
    }
    public static void GoblinStaff(EquipId equip, string from, GameObject Hand, Vector2 direction)
    {
        Gum gum = (Gum)Data.Get(equip);
        Vector2 OrginalPos = Data.ThreeToTwo(Hand.transform.position);
        //float s=Mathf
        float[] angle={ -30f,30f,0f};
        for (int i = 0; i < 3; i++)
        {
            Vector2 dir = Data.Ratote(direction,angle[i]);
            Vector2 position = OrginalPos + 2 * dir;
            Bullet.Create(gum.BulletId, gum.Demage, 0, dir, position, from);
            for (int j = 0; j < 2; j++)
            {
                Bullet.Create(gum.BulletId, gum.Demage, gum.Speed, Data.Ratote(dir, angle[j]), position, from);
            }
        }
    }
}
