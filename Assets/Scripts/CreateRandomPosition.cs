using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//フンの生成
public class CreateRangeRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    [SerializeField]
    [Tooltip("生成する個数")]
    private int numberOfPrefabsToCreate = 0;

    [SerializeField]
    [Tooltip("Paperオブジェクト")]
    private GameObject paper;

    void Start()
    {
        // paperオブジェクトが指定されていない場合はエラーメッセージを出力して終了
        if (paper == null)
        {
            Debug.LogError("Paperオブジェクトが指定されていません。");
            return;
        }

        numberOfPrefabsToCreate = 100 - Cleanliness_Status.cleanliness;

        // 指定の個数だけランダムな位置に生成
        for (int i = 0; i < numberOfPrefabsToCreate; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            //float y = 0.1f;
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // createPrefabをpaperオブジェクトの子として生成
            GameObject newPrefab = Instantiate(createPrefab, paper.transform);
            // 生成されたPrefabの位置を調整
            newPrefab.transform.position = new Vector3(x, y, z);
        }
    }
}