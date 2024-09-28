using System; // 追加
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Serializable]
// public class BirdStatus
// {
//     public bool firsttime_hunger = true;
//     public bool firsttime_clean = true;
// }

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public bool firsttime_hunger = true;
    public bool firsttime_clean = true;

    public bool IsNotify { get; set; }
    public bool IsOutput { get; set; }

    // OnEnableメソッドで初期化
    private void OnEnable()
    {
        IsNotify = PlayerPrefs.GetInt("IsNotify", 1) == 1;
        IsOutput = PlayerPrefs.GetInt("IsOutput", 1) == 1;
    }

    //public bool IsNotify; // 初期化は後
    //public bool IsOutput; // 初期化は後

    //// ScriptableObjectの初期化メソッド
    //public void Initialize()
    //{

    //}
    // public List<BirdStatus> DataList;
}
