using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Setting_TimeSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnApplicationQuit()
    {
        // ゲームが終了したときに現在の時間を保存
        PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.Save();
    }
}
