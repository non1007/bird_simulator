using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DoneName_Button : MonoBehaviour
{
    public DateTime startTime; // ゲームを始めた日時
    public Get_Name getNameObject;
    private const int HOME = 1;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    { 
        // GameSceneをロード
        PlayerPrefs.DeleteAll();
        getNameObject.InputText();
        SaveStartTime();
        StatusReset();
        PlayerPrefs.SetInt("SceneNo", HOME);
        PlayerPrefs.Save();
        SceneManager.LoadScene("home");
    }

    void SaveStartTime()
    {
        // 現在の日時をPlayerPrefsに保存
        startTime = DateTime.Now;
        PlayerPrefs.SetString("StartTime", startTime.Ticks.ToString());
    }

    void StatusReset()
    {
        //PlayerPrefs.SetFloat("Totalelapsed", 0);
        Hunger_Status.hunger = 0;
        Cleanliness_Status.cleanliness = 100;
    }
}
