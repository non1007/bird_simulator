using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public Navigation navigation;


    // public Camera firstPersonCamera;
    public Camera fixedCamera;
    private Camera onCamera;

    public SettingCamera_Button settingcamerscript;

    private float lastClickTime;
    private float autoMoveDelay = 10.0f;

    void Start()
    {
        if(navigation == null)
        {
            navigation = FindObjectOfType<Navigation>();
        }

        Navigation.isManualMove = false; 
        onCamera = fixedCamera;
    }

    void Update()
    {
        if(Navigation.isManualMove)
        {
          if(Input.GetMouseButtonDown(0)) // マウスの左クリックを検出
            {
                Vector3 clickPosition = GetClickPosition();
                if(clickPosition != Vector3.zero)
                {
                    navigation.MoveToClickPosition(clickPosition);
                    lastClickTime = Time.time;
                }
            }

            if(Time.time - lastClickTime > autoMoveDelay)
            {
                Navigation.isManualMove = false;
                navigation.OutMove();
            }
        }
    }

    public void OnButton()
    {
        Navigation.isManualMove = true;
        lastClickTime = Time.time; // 手動モード開始時にタイムスタンプを記録
    }

    private Vector3 GetClickPosition()
    {
        onCamera = settingcamerscript.OnCamera();

        Ray ray = onCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
