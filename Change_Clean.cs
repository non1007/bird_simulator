using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change_Clean : MonoBehaviour
{
    private const int CLEAN = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    { 
        PlayerPrefs.SetInt("SceneNo", CLEAN);
        PlayerPrefs.Save();
        SceneManager.LoadScene("clean");
    }
}
