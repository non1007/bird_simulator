using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Emotion : MonoBehaviour
{
    private Image emotionImage;

    [SerializeField] Sprite angerSprite;
    [SerializeField] Sprite fearSprite;
    [SerializeField] Sprite expectationSprite;
    [SerializeField] Sprite trustSprite;
    [SerializeField] Sprite sadnessSprite;
    [SerializeField] Sprite disgustSprite;
    [SerializeField] Sprite surpriseSprite;
    [SerializeField] Sprite neutralSprite;
    [SerializeField] Sprite joySprite;

    private bool isJoyActive = false; // 喜びの感情がアクティブかどうかを管理するフラグ
    public static bool isCleanFinishActive = false;

    void Start()
    {
        emotionImage = this.GetComponent<Image>();

        if(isCleanFinishActive)
        {
            JoyEmotion();
            isCleanFinishActive = false;
        }
        
        StartCoroutine(UpdateEmotionCoroutine());
    }

    // void Update()
    // {
    // }

    // 定期的に感情を更新するコルーチン
    IEnumerator UpdateEmotionCoroutine()
    {
        while(true)
        {
            if(!isJoyActive)
                ChangeEmotion(Hunger_Status.hunger, Cleanliness_Status.cleanliness);
            yield return new WaitForSeconds(10f); // 10秒待つ
        }
    }

    public void JoyEmotion()
    {
        isJoyActive = true; // 喜びの感情をアクティブにする
        emotionImage.sprite = joySprite;
        StartCoroutine(ReturnToNormalAfterDelay(10f)); // 10秒後に通常の感情に戻すコルーチンを実行
    }
    
    // 一定時間後に通常の感情に戻すコルーチン
    IEnumerator ReturnToNormalAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isJoyActive = false; // 喜びの感情を非アクティブにする
    }

    // 値に応じて感情を分類し、対応する画像を表示する関数
    void ChangeEmotion(int hunger, int cleanliness)
    {
        int randomIndex = Random.Range(0, 3); // 0から2までのランダムな数を生成

        if(hunger == 0 || cleanliness == 0)
        {
            if(randomIndex == 0)
                emotionImage.sprite = angerSprite;
            else if(randomIndex == 1)
                emotionImage.sprite = sadnessSprite;
            else
                emotionImage.sprite = neutralSprite; 
        }
        else if (hunger <= 50 || cleanliness <= 50)
        {
            if(randomIndex == 0)
                emotionImage.sprite = fearSprite;
            else if(randomIndex == 1)
                emotionImage.sprite = disgustSprite;
            else
                emotionImage.sprite = neutralSprite;
        }
        else if (hunger <= 75 || cleanliness <= 75)
        {
            if(randomIndex == 0)
                emotionImage.sprite = expectationSprite;
            else if(randomIndex == 1)
                emotionImage.sprite = surpriseSprite;
            else
                emotionImage.sprite = neutralSprite;
        }
        else
        {
            randomIndex = Random.Range(0, 2); // 0から1までのランダムな数を生成

            if(randomIndex == 0)
                emotionImage.sprite = trustSprite;
            else
                emotionImage.sprite = neutralSprite;
        }
    }
}
