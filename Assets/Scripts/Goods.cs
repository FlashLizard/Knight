using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : Item
{
    EquipId _nowId;
    int _price;
    [SerializeField]
    Text tname, tprice;

    public EquipId NowId { get => _nowId; set => _nowId = value; }
    public int Price { get => _price; set => _price = value; }

    private void Start()
    {
        this.Id = ItemId.Goods;
        if (this.NowId == EquipId.Null) this.NowId = Data.RanEquip();
        Price = Data.RanInt(20,50);
        tname.text = NowId.ToString();
        tname.color = Data.Get(NowId).Quality;
        tprice.text = Price.ToString();
        Data.FreshImage(gameObject, Data.GetImage(NowId));

    }
    public override void Interactive(GameObject user)
    {
        Player player = Data.Player.GetComponent<Player>();
        if (player.Coins >= Price)
        {
            user.GetComponent<IPickable>().Pick(NowId);
            player.Coins -= Price;
            Destroy(gameObject);
        }
    }
    public static void Create(EquipId newId, Vector3 position)
    {
        GameObject newGoods = Data.Produce("Goods", position);
        newGoods.GetComponent<Goods>().NowId = newId;
    }
}
