using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_Button : MonoBehaviour
{
    private const int START = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("SceneNo", START);
        PlayerPrefs.Save();
        SceneManager.LoadScene("start");
    }
}
