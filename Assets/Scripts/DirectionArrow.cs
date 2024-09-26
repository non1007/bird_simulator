using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrow : MonoBehaviour
{
    public Transform target; // スライド先のオブジェクトを指定
    public Canvas canvas; // UIを配置するCanvas
    public Image arrowImage; // 矢印のImage
    public Camera cam;

    void Update()
    {
        // カメラから対象までの方向を取得
        Vector3 direction = target.position - cam.transform.position;
        direction.Normalize();

        // カメラから見た方向が画面内にあるかチェック
        if (Vector3.Dot(cam.transform.forward, direction) > 0)
        {
            // WorldToScreenPointで対象の位置をスクリーン座標に変換
            Vector2 screenPos = cam.WorldToScreenPoint(target.position);

            // 矢印を配置するCanvas上の座標に変換
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, canvas.worldCamera, out canvasPos);

            // 矢印の角度を計算
            float angle = Mathf.Atan2(canvasPos.y, canvasPos.x) * Mathf.Rad2Deg;

            // 矢印を表示
            arrowImage.rectTransform.anchoredPosition = canvasPos;
            arrowImage.rectTransform.localEulerAngles = new Vector3(0, 0, angle);
            arrowImage.enabled = true;
        }
        else
        {
            // カメラから見た方向が画面外にある場合は矢印を非表示にする
            arrowImage.enabled = false;
        }
    }
}