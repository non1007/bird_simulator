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
        sceneNo = PlayerPrefs.GetInt("SceneNo", 0);
        Debug.Log(sceneNo);
        currentScene = SceneManager.GetActiveScene();
        
        if(sceneNo != currentScene.buildIndex)
        {
            SceneManager.LoadScene(sceneNo);
        }
    }
    void OnApplicationQuit()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.buildIndex);
        PlayerPrefs.SetInt("SceneNo", currentScene.buildIndex);
        PlayerPrefs.Save();
    }
}
