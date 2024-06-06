using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Net.Http.Headers;

public class LineNotify : MonoBehaviour
{
    public GameData gameData;

    // 実行すると最初に呼ばれる処理
    void Start()
    {
        //PublishMessage("インコが寂しがっています");
    }

    // 各フレーム（1秒間に24枚）ごとに処理
    void Update()
    {
        if(Hunger_Status.hunger <= 0 && gameData.firsttime_hunger)
        {
            PublishMessage("インコがおなかを空かせています");
            gameData.firsttime_hunger = false;
        }

        if(Cleanliness_Status.cleanliness <=0 && gameData.firsttime_clean)
        {
            PublishMessage("インコがケージの汚れを嫌がっています");
            gameData.firsttime_clean = false;
        }
    }

    // LINEに通知する処理
    private static async void PublishMessage(string message)
    {
        // アクセストークン
        string ACCESS_TOKEN = "GHQvCX7JohynqHt5oRNAPDJVH6AOk5pfIvvYhiZw5yI";

        // 通知
        using var client = new HttpClient();
        var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "message", message } });
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        // 実行
        await client.PostAsync("https://notify-api.line.me/api/notify", content);
    }

}