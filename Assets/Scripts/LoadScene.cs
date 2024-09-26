using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int sceneNo;
    private Scene currentScene;

    void Start() 
    {
        StartLoadScene();
    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            currentScene = SceneManager.GetActiveScene();
            PlayerPrefs.SetInt("SceneNo", currentScene.buildIndex);
            PlayerPrefs.Save();
        }
        else
        {
            StartLoadScene();
        }
       
    }
    void OnApplicationQuit()
    {
        currentScene = SceneManager.GetActiveScene();
        // Debug.Log(currentScene.buildIndex);
        PlayerPrefs.SetInt("SceneNo", currentScene.buildIndex);
        PlayerPrefs.Save();
    }

    void StartLoadScene()
    {
        sceneNo = PlayerPrefs.GetInt("SceneNo", 0);
        currentScene = SceneManager.GetActiveScene();
        
        if(sceneNo != currentScene.buildIndex)
        {
            SceneManager.LoadScene(sceneNo);
        }
    }
}
