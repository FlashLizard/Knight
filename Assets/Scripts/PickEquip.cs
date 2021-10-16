using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickEquip : Item
{
    EquipId _nowId;

    public EquipId NowId { get => _nowId; set => _nowId = value; }
    private void Start()
    {
        this.Id = ItemId.Equipment;
        if(this.NowId==EquipId.Null) this.NowId = EquipId.BigSword;
    }
    public override void Interactive(GameObject user)
    {
        user.GetComponent<IPickable>().Pick(NowId);
        Destroy(gameObject);
    }
    public static void Create(EquipId newId, Vector2 position)
    {
        GameObject newEquip = Object.Instantiate(Resources.Load<GameObject>("Prefabs/PickEquipSample"), position,new Quaternion(0,0,0,1));
        newEquip.GetComponent<PickEquip>().NowId = newId;
        Data.FreshImage(newEquip, Data.GetImage(newId));
    }
}
