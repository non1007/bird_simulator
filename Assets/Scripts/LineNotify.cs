using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.IO;

public class ConfigData
{
    public string LINE_CHANNEL_ACCESS_TOKEN { get; set; }
}

public class LineNotify : MonoBehaviour
{
    public GameData gameData;
    //private string accessToken;
    private string userId;
    private string birdname;

    //環境変数にしたい！！
    //private string channelAccessToken = "???";
    private string channelAccessToken;
    private string configPath;

    // 実行すると最初に呼ばれる処理
    void Start()
    {
        if (!gameData.IsNotify)
        {
            this.enabled = false;
        }
        else
        {
            SettingUserID();
        }
    }

    // 各フレーム（1秒間に24枚）ごとに処理
    void Update()
    {
        if(Hunger_Status.hunger <= 0 && gameData.firsttime_hunger)
        {
            //PublishMessage("インコがおなかを空かせています");
            SendMessageToUser(userId, $"{birdname}がおなかを空かせています");
            gameData.firsttime_hunger = false;
        }

        if(Cleanliness_Status.cleanliness <=0 && gameData.firsttime_clean)
        {
            //PublishMessage("インコがケージの汚れを嫌がっています");
            SendMessageToUser(userId, $"{birdname}がケージの汚れを嫌がっています");
            gameData.firsttime_clean = false;
        }
    }

    //UserIDの設定
    void SettingUserID()
    {
        string configPath = Application.dataPath + "/config.json";
        if (File.Exists(configPath))
        {
            var configText = File.ReadAllText(configPath);
            ConfigData config = JsonConvert.DeserializeObject<ConfigData>(configText);
            channelAccessToken = config.LINE_CHANNEL_ACCESS_TOKEN;
        }
        else
        {
            Debug.LogError("設定ファイルが見つかりません。");
        }

        //PublishMessage("インコが寂しがっています");
        userId = PlayerPrefs.GetString("UserId");
        // accessToken = PlayerPrefs.GetString("AccessToken");

        if (string.IsNullOrEmpty(userId))
        {
            Debug.LogError("userIDが設定されていません。");
        }

        birdname = PlayerPrefs.GetString("Name", "ななし");

        Debug.Log($"UserId: {userId}, Name: {birdname}");
    }

    // // LINEに通知する処理
    // private static async void PublishMessage(string message)
    // {
    //     // アクセストークン
    //     if(string.IsNullOrEmpty(accessToken))
    //     {
    //         Debug.LogError("AccessTokenが設定されていません。");
    //         return;
    //     }

    //     // 通知
    //     using var client = new HttpClient();
    //     var content = new FormUrlEncodedContent(new Dictionary<string, string> { { "message", message } });
    //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    //     // 実行
    //     await client.PostAsync("https://notify-api.line.me/api/notify", content);
    // }

    private async void SendMessageToUser(string userId, string message)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", channelAccessToken);
            client.BaseAddress = new System.Uri("https://api.line.me");

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                to = userId,
                messages = new[]
                {
                    new {
                        type = "text",
                        text = message
                    }
                }
            }), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/v2/bot/message/push", content);

            if(response.IsSuccessStatusCode)
            {
                Debug.Log("メッセージの送信に成功しました。");
            }
            else
            {
                Debug.LogError("メッセージの送信に失敗しました。StatusCode: " + response.StatusCode);
                Debug.LogError("エラーメッセージ: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}