using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickEquip : Item
{
    EquipId _nowId;
    [SerializeField]
    Text tname;

    public EquipId NowId { get => _nowId; set => _nowId = value; }
    private void Start()
    {
        this.Id = ItemId.Equipment;
        if(this.NowId==EquipId.Null) this.NowId = EquipId.BigSword;
        Data.FreshImage(gameObject, Data.GetImage(NowId));
        tname.text = NowId.ToString();
        tname.color = Data.Get(NowId).Quality;
    }
    public override void Interactive(GameObject user)
    {
        if (user.tag == "Player" && user.GetComponent<Player>().Skilling) return;
        user.GetComponent<IPickable>().Pick(NowId);
        Destroy(gameObject);
    }
    public static void Create(EquipId newId, Vector3 position)
    {
        GameObject newEquip = Data.Produce("PickEquip", position);
        newEquip.GetComponent<PickEquip>().NowId = newId;
    }
}
