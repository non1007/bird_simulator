using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class time : MonoBehaviour
{
    public TextMeshProUGUI text;
    //時刻の代入用
    DateTime dt;
    TimeSpan dt2;
    string dt3;
    //秒数表示しないなら不要
    double dt4;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(OnMouseDown);

        //保存した文字列設定の終了時刻をStringで取得
        dt3 = PlayerPrefs.GetString("lastTime");
     // 保存された文字列が無効な場合または空の場合は現在の日時を使用
        if (string.IsNullOrEmpty(dt3) || !DateTime.TryParse(dt3, out dt))
        {
            dt = DateTime.Now;
            PlayerPrefs.SetString("lastTime", dt.ToString());
            PlayerPrefs.Save();
        }
        dt2 = DateTime.Now - dt;
   　　 //秒数表示しないなら不要
        dt4 = dt2.TotalSeconds;
   　　 //秒数表示しないなら「"経過時間は" + dt2 + "秒です";」に差し替え
        text.text = "経過時間は" + dt4.ToString() + "秒です";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        dt = DateTime.Now;
        text.text = "計測開始";
        PlayerPrefs.SetString("lastTime", dt.ToString());
        PlayerPrefs.Save();
    }
}
