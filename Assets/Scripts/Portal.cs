using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Item
{
    private void Start()
    {
        this.Id = ItemId.Portal;
    }
    public override void Interactive(GameObject user)
    {
        Data.Remain();
        Data.Level++;
        SceneManager.LoadScene("Level01");
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("Portal", position);
    }
}
