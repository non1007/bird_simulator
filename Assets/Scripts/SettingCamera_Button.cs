using UnityEngine;

public class SettingCamera_Button : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera fixedCamera;
    public Transform targetObject; // �؂�ւ���Ώۂ̃I�u�W�F�N�g
    public Bubble_Position bubble_position;

    private void Start()
    {
        // �ŏ��͈�l�̎��_�̃J�������A�N�e�B�u�ɂ���
        firstPersonCamera.enabled = false;
        fixedCamera.enabled = true;
    }

    public void SwitchCamera()
    {
        // ��l�̎��_�̃J�������A�N�e�B�u�ɂ���
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

        // ��l�̎��_�̃J�����̈ʒu�ƒ����_���I�u�W�F�N�g�ɐݒ肷��
        //firstPersonCamera.transform.position = targetObject.position;
        //firstPersonCamera.transform.rotation = targetObject.rotation;
    }

    public Camera OnCamera()
    {
        if(firstPersonCamera.enabled)
        {
          return firstPersonCamera;
        }
        else
        {
          return fixedCamera;
        }

    }
}
