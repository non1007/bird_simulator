using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_Button : MonoBehaviour
{
    private const int HOME = 1;
    private int count_clean;
    void Start()
    {
        count_clean = PlayerPrefs.GetInt("CountClean", count_clean);
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

    public void OnCancelCleanButton()
    {
        count_clean--;
        PlayerPrefs.SetInt("CountClean", count_clean);
        PlayerPrefs.Save();
    }
}
