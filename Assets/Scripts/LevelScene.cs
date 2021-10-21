using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{
    [SerializeField]
    Text tLevel;
    private void Awake()
    {
        Data.Load();
        
    }
    private void Start()
    {
        if (Data.Level == 5)
        {
            Data.Clear();
            SceneManager.LoadScene("Win");
        }
        Data.Player.transform.position = new Vector3(0, 0);
        tLevel.text = "Level 1-" + (Data.Level+1);
    }
}
