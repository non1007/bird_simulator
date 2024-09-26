using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//満腹度を変化させる
public class Hunger_Status : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hungerText;
    string lastPlayTimeString;
    string lastPlayTimeStateString;
    DateTime lastPlayTime;
    DateTime lastPlayTimeState;
    TimeSpan elapsed;
    TimeSpan elapsedState;
    int decreaseAmount;
    
    public GameObject bird;
    private Animator animator;

    public static int hunger;

    public GameData gameData; 

    public AudioSource audioSource;

    [SerializeField] GameObject image;

    Coroutine decreaseCoroutine;

    void Start()
    {
        animator = bird.GetComponent<Animator>();

        StartHunger();
    }

    void Update()
    {
        hungerText.text = "満腹度：" + hunger + "%";

        if(hunger <= 0)
        {
            //hungerが0になった時点で時刻を保存
            if(!PlayerPrefs.HasKey("LastPlayTimeHunger"))
            {
                PlayerPrefs.SetString("LastPlayTimeHunger", DateTime.Now.ToString());
            }
            StatePet();
        }
        else
        {
            //hungerが0でない場合は保存された時刻をリセット
            PlayerPrefs.DeleteKey("LastPlayTimeHunger");
        }


    }

    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            PlayerPrefs.SetInt("Hunger", hunger);
            PlayerPrefs.Save();
            if(decreaseCoroutine != null)
            {
                StopCoroutine(decreaseCoroutine);
            }
        }
        else
        {
            StartHunger();
        }
       
    }

    public void OnApplicationQuit()
    {
        // ゲームが終了したときに現在の時間を保存
        //PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.SetInt("Hunger", hunger);
        PlayerPrefs.Save();
        StopCoroutine(DecreaseHunger());
    }

    public void StartHunger()
    {
        if(PlayerPrefs.HasKey("Hunger"))
        {
            hunger = PlayerPrefs.GetInt("Hunger"); 
        }
        else
        {
            Debug.Log("満腹度がありません");
            Count_Display.error++;
            PlayerPrefs.SetInt("Error", Count_Display.error);
            PlayerPrefs.Save();
        }

        UpdateTimeHunger();

        if(decreaseCoroutine != null)
        {
            StopCoroutine(decreaseCoroutine);
        }

        decreaseCoroutine = StartCoroutine(DecreaseHunger());         
    }

    public void CountHunger()
    {
        hunger += 50;

        hunger = Mathf.Min(hunger, 100);

        gameData.firsttime_hunger = true;
    }

    IEnumerator DecreaseHunger()
    {
        while(true)
        {
            yield return new WaitForSeconds(216);

            hunger -= 1;
            
            hunger = Mathf.Max(hunger, 0);
        }
    }

    void UpdateTimeHunger()
    {
        // ゲームが起動したときに前回のプレイ終了時刻から経過時間を考慮して満腹度を更新
        // 前回のプレイ終了時刻を取得
        lastPlayTimeString = PlayerPrefs.GetString("LastPlayTime", DateTime.Now.ToString());

        lastPlayTime = DateTime.Parse(lastPlayTimeString);
        elapsed = DateTime.Now - lastPlayTime;

            // 経過時間に基づいて満腹度を減少させる
        decreaseAmount = (int)Math.Floor(elapsed.TotalSeconds) / 216;
        hunger -= decreaseAmount;
        hunger = Mathf.Max(hunger, 0);
    }

    void StatePet()
    {
        lastPlayTimeStateString = PlayerPrefs.GetString("LastPlayTimeHunger", "");

        if(!string.IsNullOrEmpty(lastPlayTimeStateString))
        {
            lastPlayTimeState = DateTime.Parse(lastPlayTimeStateString);
            elapsedState = DateTime.Now - lastPlayTimeState;

            // 経過時間が一日ならdie状態
            if(elapsedState.TotalDays >= 1.0)
            {
                Dead();
            }
        }
    }

    void Dead()
    {
        animator.SetBool("IsLived", false);
        image.SetActive(false);
        audioSource.Stop();
        StopCoroutine(DecreaseHunger());
    }
}
