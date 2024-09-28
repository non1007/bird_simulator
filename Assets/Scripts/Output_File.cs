using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Output_File : MonoBehaviour
{
    private StreamWriter swh;
    private StreamWriter swc;
    private StreamWriter swb;
    private Coroutine hungerCoroutine;
    private Coroutine cleanCoroutine;

    //private bool isPaused = false; // アプリが一時停止中かどうかを追跡するフラグ

    private string FilePathHunger;
    private string FilePathClean;
    private string FilePathButton;

    private bool isFirstOpen = true;
    public bool isNight;
    public GameData gameData;

    void Start()
    {
        if (!gameData.IsOutput)
        {
            this.enabled = false;
        }
        else
        {
            SettingOutput();
        }
    }

    void SettingOutput()
    {
        isNight = false;
        SetFilePaths();
        OpenFiles();
        StartCoroutines();
    }

    void SetFilePaths()
    {
#if UNITY_IOS
        // 新しくcsvファイルを作成して、{}の中の要素分csvに追記をする(iOSの処理)
        FilePathHunger = Application.persistentDataPath + @"/HungerDate.csv";
        FilePathClean = Application.persistentDataPath + @"/CleanDate.csv";
        FilePathButton = Application.persistentDataPath + @"/ButtonDate.csv";
#endif

#if UNITY_EDITOR
        // 新しくcsvファイルを作成して、{}の中の要素分csvに追記をする(Unity上での処理)
        FilePathHunger = @"HungerDate.csv";
        FilePathClean = @"CleanDate.csv";
        FilePathButton = @"ButtonDate.csv";
#endif
    }
    void OpenFiles()
    {
// #if UNITY_IOS
//         // 新しくcsvファイルを作成して、{}の中の要素分csvに追記をする(iOSの処理)
//         string FilePathHunger = @"/HungerDate.csv";
//         swh = new StreamWriter(Application.persistentDataPath + FilePathHunger, true, Encoding.GetEncoding("utf-8"));

//         string FilePathClean = @"/CleanDate.csv";
//         swc = new StreamWriter(Application.persistentDataPath + FilePathClean, true, Encoding.GetEncoding("utf-8"));

//         string FilePathButton = @"/ButtonDate.csv";
//         swb = new StreamWriter(Application.persistentDataPath + FilePathButton, true, Encoding.GetEncoding("utf-8"));
// #endif

// #if UNITY_EDITOR
//         // 新しくcsvファイルを作成して、{}の中の要素分csvに追記をする(Unity上での処理)
//         swh = new StreamWriter(@"HungerDate.csv", true, Encoding.GetEncoding("Shift_JIS"));
//         swc = new StreamWriter(@"CleanDate.csv", true, Encoding.GetEncoding("Shift_JIS"));
//         swb = new StreamWriter(@"ButtonDate.csv", true, Encoding.GetEncoding("Shift_JIS"));
// #endif

        //add
        isFirstOpen = !File.Exists(FilePathHunger) || !File.Exists(FilePathClean) || !File.Exists(FilePathButton);

        swh = new StreamWriter(FilePathHunger, true, Encoding.GetEncoding("utf-8"));
        swc = new StreamWriter(FilePathClean, true, Encoding.GetEncoding("utf-8"));
        swb = new StreamWriter(FilePathButton, true, Encoding.GetEncoding("utf-8"));
        
        if(isFirstOpen)
        {
            Debug.Log("File open first time.");
            // CSV1行目のカラムで、StreamWriter オブジェクトへ書き込む 
            string[] s1 = { "日にち(日)", "パーセント(%)", "日付" , $"{System.DateTime.Now.ToString()}"};
            string s2 = string.Join(",", s1);
            swh.WriteLine(s2);
            swc.WriteLine(s2);
              
            string[] s3 = { "押したボタン", "日付" , $"{System.DateTime.Now.ToString()}"};
            string s4 = string.Join(",", s3);
            swb.WriteLine(s4);
        }
        //add
        if(isNight)
        {
            Save("おはよう");
        }
        else
        {
            Save("セーブ");
        }

    }
    
    void StartCoroutines()
    {
        hungerCoroutine = StartCoroutine(HungerPeriodically());
        cleanCoroutine = StartCoroutine(CleanPeriodically());
    }

    public void Save(string txt)
    {
        SaveHungerData(txt, $"{Hunger_Status.hunger.ToString()}", $"{System.DateTime.Now.ToString()}");
        SaveCleanData(txt, $"{Cleanliness_Status.cleanliness.ToString()}", $"{System.DateTime.Now.ToString()}");
    }

    // コルーチンメソッド
    private IEnumerator HungerPeriodically()
    {
        while(true)
        {
            Debug.Log("Saving hunger data...");
            yield return new WaitForSeconds(216);
            SaveHungerData($"{Set_Day.elapsedDays.ToString()}", $"{Hunger_Status.hunger.ToString()}", $"{System.DateTime.Now.ToString()}");
        }
    }

    private IEnumerator CleanPeriodically()
    {
        while(true)
        {
            Debug.Log("Saving clean data...");
            yield return new WaitForSeconds(864);
            SaveCleanData($"{Set_Day.elapsedDays.ToString()}", $"{Cleanliness_Status.cleanliness.ToString()}", $"{System.DateTime.Now.ToString()}");
        }
    }

    public void SaveHungerData(string txt1, string txt2, string txt3)
    {
        string[] s1 = {txt1, txt2, txt3};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing hunger data: " + s2);
        swh.WriteLine(s2);
        swh.Flush(); // データを確実に書き込む
    }

    public void SaveCleanData(string txt1, string txt2, string txt3)
    {
        string[] s1 = {txt1, txt2, txt3};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing clean data: " + s2);
        swc.WriteLine(s2);
        swc.Flush();
    }

    public void SaveFoodButtonData()
    {
        string[] s1 = {"ごはん", $"{System.DateTime.Now.ToString()}"};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing food button data: " + s2);
        swb.WriteLine(s2);
        swb.Flush();

        SaveHungerData("ごはん", $"{Hunger_Status.hunger.ToString()}", $"{System.DateTime.Now.ToString()}");
    }

    public void SaveCleanButtonData()
    {
        string[] s1 = {"おそうじ", $"{System.DateTime.Now.ToString()}"};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing clean button data: " + s2);
        swb.WriteLine(s2);
        swb.Flush();

        SaveCleanData("おそうじ", $"{Cleanliness_Status.cleanliness.ToString()}", $"{System.DateTime.Now.ToString()}");
    }

    public void SaveCameraButtonData()
    {
        string[] s1 = {"かめら", $"{System.DateTime.Now.ToString()}"};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing camera button data: " + s2);
        swb.WriteLine(s2);
        swb.Flush();
    }

    //add
    public void SaveTouchButtonData()
    {
        string[] s1 = {"タッチ", $"{System.DateTime.Now.ToString()}"};
        string s2 = string.Join(",", s1);
        Debug.Log("Writing touch button data: " + s2);
        swb.WriteLine(s2);
        swb.Flush();
    }

    public void FileCloseButton()
    {
        Debug.Log("Closing files with button...");
        FileClose();
        OpenFiles();
        StartCoroutines();
    }

    public void FileClose()
    {
        Debug.Log("Closing files...");
        if(swh != null)
        {
            swh.Close();
        }

        if(swc != null)
        {
            swc.Close();
        }

        if(swb != null)
        {
            swb.Close();
        }

        if(hungerCoroutine != null)
        {
            StopCoroutine(hungerCoroutine);
            hungerCoroutine = null;
        }

        if(cleanCoroutine != null)
        {
            StopCoroutine(cleanCoroutine);
            cleanCoroutine = null;
        }
    }

    // OnApplicationQuitでファイルをクローズ
    private void OnApplicationQuit()
    {
        Debug.Log("Application quitting, closing files...");
        FileClose();
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            Debug.Log("Application paused, closing files...");
            FileClose();
        }
        else
        {
            Debug.Log("Application resumed, starting coroutines...");
            OpenFiles();
            StartCoroutines();
        }
    }
}
