using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Time_setting : MonoBehaviour
{
    private bool sceneSwitched = false;
    private const int DARK = 3;


    DateTime currentTime;

    void Start()
    {
        //sceneSwitched = false;
    }
    void Update()
    {
        currentTime = DateTime.Now;

        if(currentTime.Hour == 22 && !sceneSwitched)
        //if(currentTime.Hour < 7 || currentTime.Hour >= 22)
        {
            PlayerPrefs.SetInt("SceneNo", DARK);
            PlayerPrefs.Save();
            SceneManager.LoadScene("dark");
            sceneSwitched = true; // シーンが切り替わったことを記録
        }
    }
}
