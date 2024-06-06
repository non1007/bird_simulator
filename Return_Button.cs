using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_Button : MonoBehaviour
{
    private const int HOME = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()
    {
        PlayerPrefs.SetInt("SceneNo", HOME);
        PlayerPrefs.Save();
        SceneManager.LoadScene("home");
    }
}
