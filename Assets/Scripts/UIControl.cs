using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        Data.Clear();
        SceneManager.LoadScene("Level01");
        Data.SettingUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainClick()
    {
        Data.Clear();
        SceneManager.LoadScene("Main");
        Data.SettingUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void WinClick()
    {
        string name = GameObject.Find("Name").GetComponent<Text>().text;
        GameObject.Find("WinUI").SetActive(false);
        GameObject.Find("NextUI").SetActive(true);
        GameObject.Find("WinTile").GetComponent<Text>().text = "STO " + name + " OTZ";
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
