using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Time_setting_dark : MonoBehaviour
{
    private bool sceneSwitched = false;
    private const int HOME = 1;
    DateTime currentTime;

    void Start()
    {
        //sceneSwitched = false;
    }
    void Update()
    {
        currentTime = DateTime.Now;

        if (currentTime.Hour == 7 && !sceneSwitched)
        // if (currentTime.Hour >= 7 || currentTime.Hour < 22)
        {
            PlayerPrefs.SetInt("SceneNo", HOME);
            PlayerPrefs.Save();
            SceneManager.LoadScene("home");
            sceneSwitched = true; // シーンが切り替わったことを記録
        }
    }
}
