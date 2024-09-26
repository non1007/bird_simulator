using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//昼モードに切り替える
public class Time_setting_dark : MonoBehaviour
{
    // private bool sceneSwitched = false;
    private const int HOME = 1;

    private Scene nowScene;

    DateTime nowTime;

    [SerializeField] GameObject status;

    void Start()
    {
        nowScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        nowTime = DateTime.Now;

        //if (currentTime.Hour == 7 && !sceneSwitched)
        if((nowTime.Hour >= 7 && nowTime.Hour < 22) && nowScene.name != "home")
        {
            PlayerPrefs.SetInt("SceneNo", HOME);
            //ゲームが終わった時と同じ動作をする
            PlayerPrefs.SetInt("Cleanliness", Cleanliness_Status.cleanliness);
            PlayerPrefs.SetInt("Hunger", Hunger_Status.hunger);
            Setting_Save.SetBool("StatusActive", status.activeSelf);
            // PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
            SceneManager.LoadScene("home");
            // sceneSwitched = true; // シーンが切り替わったことを記録
        }
    }
}
