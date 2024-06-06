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
    // public List<BirdStatus> DataList;
}
