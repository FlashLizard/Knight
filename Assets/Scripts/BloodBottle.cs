using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBottle : Item
{
    private void Start()
    {
        this.Id = ItemId.BloodBottle;
    }
    public override void Interactive(GameObject user)
    {
        Player player=Data.Player.GetComponent<Player>();
        if (player.Health == Player.maxHealth) return;
        player.Health += 2;
        Destroy(gameObject);
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("BloodBottle", position);
    }
}
