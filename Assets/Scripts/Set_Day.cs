using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//経過日数を計算
public class Set_Day : MonoBehaviour
{
    private DateTime starttime;
    private DateTime currenttime;
    static public int elapsedDays;
    private TextMeshProUGUI tmp;
    private const int MORNING = 7; // 朝の時刻


    void Start()
    {
        // ゲームを始めた日時を取得
        starttime = GetStartTime();
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currenttime = DateTime.Now;

        // 経過日数を計算
        elapsedDays = ElapsedDays(starttime, currenttime);
        tmp.text = elapsedDays.ToString() + "日目";
    }

    private DateTime GetStartTime()
    {
        // PlayerPrefsからゲームを始めた日時を取得
        if(PlayerPrefs.HasKey("StartTime"))
        {
            long ticks = Convert.ToInt64(PlayerPrefs.GetString("StartTime"));
            return new DateTime(ticks);
        }
        else
        {
            Debug.Log("はじめた日付がわかりません");
            // ゲームを始めた日時が保存されていない場合は現在の日時を返す
            return DateTime.Now;        
        }
    }

    private int ElapsedDays(DateTime startDate, DateTime endDate)
    {
        // 経過日数を計算
        int elapsedDays = (int)(endDate.Date - startDate.Date).TotalDays;

        elapsedDays++;

        if(startDate.Hour > MORNING)
        {
            if(endDate.Hour < MORNING)
            {
                //7時よりmae
                elapsedDays--;
            }
        }
        else
        {
            Debug.Log("開始時間がはやすぎます");
        }

        return elapsedDays;
    }
}
