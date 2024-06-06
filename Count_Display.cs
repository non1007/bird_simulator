using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Count_Display : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elapsedText;
    [SerializeField] TextMeshProUGUI countfoodText;
    [SerializeField] TextMeshProUGUI countcleanText;

    TimeSpan elapsed;
    private DateTime game_starttime;
    private double elapsed_second;
    //private double totalelapsed;
    private int totalelapsed;

    private int hours;
    private int minutes;
    private int seconds;

    private int count_food;
    private int count_clean;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);

        game_starttime = DateTime.Now;

        count_food = PlayerPrefs.GetInt("CountFood", 0);
        count_clean = PlayerPrefs.GetInt("CountClean", 0);
        totalelapsed = PlayerPrefs.GetInt("Totalelapsed", 0);

        UpdateElapsedText();
    }

    // Update is called once per frame
    void Update()
    {
        countfoodText.text = $"ごはんを食べた回数: {count_food}回";
        countcleanText.text = $"そうじをした回数: {count_clean}回";
    }

    public void OnApplicationQuit()
    {
        UpdateTimeElapsed();
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            UpdateTimeElapsed();
        }
        else
        {
            game_starttime = DateTime.Now;
        }
    }

    void OnDisable()
    {
        UpdateTimeElapsed();
    }

    void UpdateTimeElapsed()
    {
        elapsed = DateTime.Now - game_starttime;
        totalelapsed += (int)elapsed.TotalSeconds; //2week想定なので
        Debug.Log(totalelapsed);
        PlayerPrefs.SetInt("Totalelapsed", totalelapsed);

        PlayerPrefs.Save();
        UpdateElapsedText();
        game_starttime = DateTime.Now;
    }

    public void OnFoodButton()
    {
        count_food++;
        Debug.Log(count_food);
        PlayerPrefs.SetInt("CountFood", count_food);
        PlayerPrefs.Save();
    }

    public void OnCleanButton()
    {
        count_clean++;
        PlayerPrefs.SetInt("CountClean", count_clean);
        PlayerPrefs.Save();
    }

    void UpdateElapsedText()
    {
        hours = (int)(totalelapsed / 3600);
        minutes = (int)((totalelapsed % 3600) / 60);
        seconds = (int)(totalelapsed % 60);
        elapsedText.text = $"起動時間: {hours}時間 {minutes}分 {seconds}秒";
    }
}
