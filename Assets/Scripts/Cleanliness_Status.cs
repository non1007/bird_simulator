using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//清潔度を変化させる
public class Cleanliness_Status : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cleanlinessText;
    string lastPlayTimeString;
    string lastPlayTimeStateString;
    DateTime lastPlayTime;
    DateTime lastPlayTimeState;
    TimeSpan elapsed;
    TimeSpan elapsedState;
    int decreaseAmount;
    
    public GameObject bird;
    private Animator animator;

    public static int cleanliness;
    Coroutine decreaseCoroutine;

    void Start()
    {
        animator = bird.GetComponent<Animator>();

        StartClean();
    }

    // Update is called once per frame
    void Update()
    {
        cleanlinessText.text = "清潔度：" + cleanliness + "%";

        if(cleanliness <= 0)
        {
            // cleanlinessが0になった時点で時刻を保存
            if(!PlayerPrefs.HasKey("LastPlayTimeClean"))
            {
                PlayerPrefs.SetString("LastPlayTimeClean", DateTime.Now.ToString());
            }
            StatePet();
        }
        else
        {
            // cleanlinessが0でない場合は保存された時刻をリセット
            PlayerPrefs.DeleteKey("LastPlayTimeClean");
        }

    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            PlayerPrefs.SetInt("Cleanliness", cleanliness);
            PlayerPrefs.Save();
            if(decreaseCoroutine != null)
            {
                StopCoroutine(decreaseCoroutine);
            }
        }
        else
        {
            StartClean();
        }
       
    }

    public void OnApplicationQuit()
    {
        // ゲームが終了したときに現在の時間を保存
        //PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.SetInt("Cleanliness", cleanliness);
        PlayerPrefs.Save();
        StopCoroutine(DecreaseCleanliness());
    }

    void StartClean()
    {
        if(PlayerPrefs.HasKey("Cleanliness"))
        {
            cleanliness = PlayerPrefs.GetInt("Cleanliness");
        }
        else
        {
            Debug.Log("清潔度がありません");
            Count_Display.error++;
            PlayerPrefs.SetInt("Error", Count_Display.error);
            PlayerPrefs.Save();
        }
        // cleanliness = 20; 

        UpdateTimeClean();

        if(decreaseCoroutine != null)
        {
            StopCoroutine(decreaseCoroutine);
        }

        decreaseCoroutine = StartCoroutine(DecreaseCleanliness());
    }

    IEnumerator DecreaseCleanliness()
    {
        while(true)
        {
            yield return new WaitForSeconds(864);

            cleanliness -= 1;
            
            cleanliness = Mathf.Max(cleanliness, 0);
        }
    }

    void UpdateTimeClean()
    {
        // ゲームが起動したときに前回のプレイ終了時刻から経過時間を考慮して清潔度を更新
        // 前回のプレイ終了時刻を取得
        lastPlayTimeString = PlayerPrefs.GetString("LastPlayTime", DateTime.Now.ToString());

        lastPlayTime = DateTime.Parse(lastPlayTimeString);
        elapsed = DateTime.Now - lastPlayTime;

        // 経過時間に基づいて清潔度を減少させる
        decreaseAmount = (int)Math.Floor(elapsed.TotalSeconds) / 864;
        cleanliness -= decreaseAmount;
        cleanliness = Mathf.Max(cleanliness, 0);
    }

    void StatePet()
    {
        lastPlayTimeStateString = PlayerPrefs.GetString("LastPlayTimeClean", "");

        if (!string.IsNullOrEmpty(lastPlayTimeStateString))
        {
            lastPlayTimeState = DateTime.Parse(lastPlayTimeStateString);
            elapsedState = DateTime.Now - lastPlayTimeState;

            // 経過時間が一日ならill状態
            if(elapsedState.TotalDays >= 1.0)
            {
                if(animator.GetBool("IsLived"))
                {
                    animator.SetBool("IsIll", true);
                }
            }
        }
    }
}
