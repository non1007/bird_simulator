using UnityEngine;

public class SettingCamera_Button : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera fixedCamera;
    public Transform targetObject; // 切り替える対象のオブジェクト
    public Bubble_Position bubble_position;

    private void Start()
    {
        // 最初は一人称視点のカメラをアクティブにする
        firstPersonCamera.enabled = false;
        fixedCamera.enabled = true;
    }

    public void SwitchCamera()
    {
        // 一人称視点のカメラをアクティブにする
        firstPersonCamera.enabled = !firstPersonCamera.enabled;
        fixedCamera.enabled = !fixedCamera.enabled;

        if(firstPersonCamera.enabled)
        {
          bubble_position.cam = firstPersonCamera;
        }
        else
        {
          bubble_position.cam = fixedCamera;
        }

        // 一人称視点のカメラの位置と注視点をオブジェクトに設定する
        //firstPersonCamera.transform.position = targetObject.position;
        //firstPersonCamera.transform.rotation = targetObject.rotation;
    }
}
