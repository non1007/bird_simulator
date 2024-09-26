using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//夜モードに切り替える
public class Time_setting : MonoBehaviour
{
    // private bool sceneSwitched = false;
    private const int DARK = 3;

    private Scene nowScene;

    [SerializeField] GameObject status;

    public Output_File output;


    DateTime nowTime;

    void Start()
    {
        nowScene = SceneManager.GetActiveScene();
        Debug.Log(nowTime.Hour);
    }
    void Update()
    {
        nowTime = DateTime.Now;
        // Debug.Log(nowTime.Hour);

        //if(currentTime.Hour > 22 && !sceneSwitched)
        if((nowTime.Hour < 7 || nowTime.Hour >= 22) && (nowScene.name != "dark"))
        {
            PlayerPrefs.SetInt("SceneNo", DARK);
            //ゲームが終わった時と同じ動作をする
            PlayerPrefs.SetInt("Cleanliness", Cleanliness_Status.cleanliness);
            PlayerPrefs.SetInt("Hunger", Hunger_Status.hunger);
            Setting_Save.SetBool("StatusActive", status.activeSelf);
            //add
            output.Save("お休み");
            output.isNight = true;
            output.FileClose();
            // PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
            PlayerPrefs.Save();

            SceneManager.LoadScene("dark");
            // sceneSwitched = true; // シーンが切り替わったことを記録
        }
    }
}
