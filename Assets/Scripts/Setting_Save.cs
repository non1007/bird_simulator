using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステータス表示を以前の設定どおりに表示する
public class Setting_Save : MonoBehaviour
{
    public bool status_on;
    [SerializeField] GameObject status;
    [SerializeField] GameObject notify;

    // Start is called before the first frame update
    void Start()
    {
        status_on = GetBool("StatusActive", false);
        status.SetActive(status_on);
        notify.SetActive(status_on);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SetBool("StatusActive", status.activeSelf);
        }
        else
        {
            status_on = GetBool("StatusActive", false);
            status.SetActive(status_on);
            notify.SetActive(status_on);
        }
    }

    public void OnApplicationQuit()
    {
        SetBool("StatusActive", status.activeSelf);
    }

    public static bool GetBool(string key, bool defalutValue)
    {
        var value = PlayerPrefs.GetInt(key, defalutValue ? 1 : 0);
        return value == 1;
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }
}
