using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Line.LineSDK;

public class LineLogin : MonoBehaviour {

    //public string accessToken;
    private string userid;
    //public LineNotify lineNotify;
    void Start()
    {
        //lineNotify = FindObjectOfType<LineNotify>();
    }

    void Update()
    {
        
    }

    public void LoginButtonClicked() {
        var scopes = new string[] {"profile", "openid"};
        LineSDK.Instance.Login(scopes, result => {
            result.Match(
                value => {
                    Debug.Log("Login OK. User display name: " + value.UserProfile.DisplayName);
                    //accessToken = value.AccessToken.Value; // アクセストークンを保存
                    //lineNotify.SetUserId(value.UserProfile.UserId); // LineNotifyクラスにユーザーIDを渡す
                    PlayerPrefs.SetString("UserId", value.UserProfile.UserId);
                    PlayerPrefs.SetString("AccessToken", value.AccessToken.Value);
                    PlayerPrefs.Save();
                },
                error => {
                    Debug.Log("Login failed, reason: " + error.Message);
                    //accessToken = "GHQvCX7JohynqHt5oRNAPDJVH6AOk5pfIvvYhiZw5"; //開発者の
                    //lineNotify.SetUserId("soraziyuu"); // LineNotifyクラスにユーザーIDを渡す
                }
            );
        });
    }
}