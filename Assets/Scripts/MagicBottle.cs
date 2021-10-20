using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBottle : Item
{
    private void Start()
    {
        this.Id = ItemId.MagicBottle;
    }
    public override void Interactive(GameObject user)
    {
        Player player = Data.Player.GetComponent<Player>();
        if (player.Magic == Player.maxMagic) return;
        player.Magic += 50;
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("MagicBottle", position);
    }
}
