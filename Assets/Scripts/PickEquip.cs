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
        Data.FreshImage(gameObject, Data.GetImage(NowId));
    }
    public override void Interactive(GameObject user)
    {
        user.GetComponent<IPickable>().Pick(NowId);
        Destroy(gameObject);
    }
    public static void Create(EquipId newId, Vector3 position)
    {
        GameObject newEquip = Data.Produce("PickEquip", position);
        newEquip.GetComponent<PickEquip>().NowId = newId;
    }
}
