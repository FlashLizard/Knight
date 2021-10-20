using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Data.SettingUI.GetComponent<UIControl>().NewGameClick();
        }
    }
}
