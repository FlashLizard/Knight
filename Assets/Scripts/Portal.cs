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
        DontDestroyOnLoad(Data.Player);
        DontDestroyOnLoad(Data.StatusUI);
        DontDestroyOnLoad(Data.SettingUI);
        SceneManager.LoadScene("Level01");
    }
    public static void Create(Vector3 position)
    {
        Data.Produce("Portal", position);
    }
}
