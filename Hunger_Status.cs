using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hunger:"+hunger);
        hunger = PlayerPrefs.GetInt("Hunger", 0); 
        //Debug.Log("hunger:"+hunger);

        animator = bird.GetComponent<Animator>();

        UpdateTimeHunger();

        //InvokeRepeating("DecreaseHunger", 0, 216);
        StartCoroutine(DecreaseHunger());
    }

    // Update is called once per frame
    void Update()
    {
        hungerText.text = "満腹度：" + hunger + "%";

        if(hunger <= 0)
        {
            //hungerが0になった時点で時刻を保存
            if (!PlayerPrefs.HasKey("LastPlayTimeHunger"))
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

    public void OnApplicationQuit()
    {
        // ゲームが終了したときに現在の時間を保存
        //PlayerPrefs.SetString("LastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.SetInt("Hunger", hunger);
        PlayerPrefs.Save();
    }

    void UpdateTimeHunger()
    {
        // ゲームが起動したときに前回のプレイ終了時刻から経過時間を考慮して満腹度を更新

        // 前回のプレイ終了時刻を取得
        lastPlayTimeString = PlayerPrefs.GetString("LastPlayTime", "");

        if (!string.IsNullOrEmpty(lastPlayTimeString))
        {
            lastPlayTime = DateTime.Parse(lastPlayTimeString);
            elapsed = DateTime.Now - lastPlayTime;

            // 経過時間に基づいて満腹度を減少させる
            decreaseAmount = (int)Math.Floor(elapsed.TotalSeconds) / 216;

            hunger -= decreaseAmount;

            hunger = Mathf.Max(hunger, 0);

        }
    }

    void StatePet()
    {
        lastPlayTimeStateString = PlayerPrefs.GetString("LastPlayTimeHunger", "");

        if (!string.IsNullOrEmpty(lastPlayTimeStateString))
        {
            lastPlayTimeState = DateTime.Parse(lastPlayTimeStateString);
            elapsedState = DateTime.Now - lastPlayTimeState;

            // 経過時間が一日ならdie状態
            if(elapsedState.TotalDays >= 1.0)
            {
                animator.SetBool("IsLived", false);
            }
        }
    }
}
