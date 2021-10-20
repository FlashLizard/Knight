using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScene : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Data.StatusUI);
        Debug.Log(Data.Player);
    }
    private void Start()
    {
        Data.Player.transform.position = new Vector3(0, 0);
       // Player player = Data.Player.GetComponent<Player>();
        //player.Health = player.Health;
        //player.Magic = player.Magic;
        //player.Coins = player.Coins;
        //player.Defence = player.Defence;
    }
}
