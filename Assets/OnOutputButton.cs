using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOutputButton : MonoBehaviour
{
    public GameData gameData;

    public void OnOutputYesButton()
    {
        gameData.IsOutput = true;
        PlayerPrefs.SetInt("IsOutput", 1);
        PlayerPrefs.Save();
    }

    public void OnOutputNoButton()
    {
        gameData.IsOutput = false;
        PlayerPrefs.SetInt("IsOutput", 0);
        PlayerPrefs.Save();
    }
}
