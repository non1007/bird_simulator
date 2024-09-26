using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


//おそうじボタン押下時
public class Change_Clean : MonoBehaviour
{
    private const int CLEAN = 2;

    [SerializeField] GameObject status;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClean()
    { 
        Setting_Save.SetBool("StatusActive", status.activeSelf);
        PlayerPrefs.SetInt("SceneNo", CLEAN);
        PlayerPrefs.SetInt("Hunger", Hunger_Status.hunger);
        //おそうじに遷移したときの時間を保存
        PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.Save();
        SceneManager.LoadScene("clean");
    }
}
