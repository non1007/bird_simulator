using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//新しく飼うボタン
public class Rebirth_Button : MonoBehaviour
{
    // アニメーター
    [SerializeField]
    private Animator petanimator;

    private const int START = 0;

    void Start()
    {
        // gameObject.GetComponent<Button>().onClick.AddListener(StartGame);      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RebirthButton()
    { 
        petanimator.SetBool("IsLive", true);
        // 保存されているすべてのデータを消す
        PlayerPrefs.DeleteAll();
        // GameSceneをロード
        PlayerPrefs.SetInt("SceneNo", START);
        PlayerPrefs.Save();
        SceneManager.LoadScene("start");
    }
}
