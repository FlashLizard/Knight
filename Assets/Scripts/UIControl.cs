using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    public void SettingsClick()
    {
        Data.SettingUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitClick()
    {
        Data.SettingUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void NewGameClick()
    {
        DontDestroyOnLoad(Data.SettingUI);
        SceneManager.LoadScene("Level01");
        Data.SettingUI.SetActive(false);
        Time.timeScale = 1;
    }
}
