using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNotifyButton : MonoBehaviour
{
    public GameData gameData;

    //お知らせする
    public void OnNotifyYesButton()
    {
        gameData.IsNotify = true;
        PlayerPrefs.SetInt("IsNotify", 1);
        PlayerPrefs.Save();
    }

    //お知らせしない
    public void OnNotifyNoButton()
    {
        gameData.IsNotify = false;
        PlayerPrefs.SetInt("IsNotify", 0);
        PlayerPrefs.Save();
    }
}
