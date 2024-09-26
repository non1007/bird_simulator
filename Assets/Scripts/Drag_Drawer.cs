using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//引き出しトレイの設定、おそうじ終了
public class Drag_Drawer : MonoBehaviour
{
    public Camera cam;
    public bool isDragging;
    static public bool attentionDrag;
    static public bool finish;
    private Vector3 offset;
    private Vector3 inputPosition;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text6;
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;

    [SerializeField] GameObject dirtypaper;
    [SerializeField] GameObject wire;

    public GameData gameData;    
    private const int HOME = 1;
    private const float FRONT = 6.0f;
    private const float BACK = 4.58f;

    public Setting_Instruction setinst;


    // [SerializeField]z
    // private GameObject wirobj;
    void Start()
    {
        isDragging = false;
        attentionDrag = true;
        finish = false;
    }

    void Update()
    {
        inputPosition = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(inputPosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == (this.gameObject || dirtypaper.gameObject || wire.gameObject) && attentionDrag)
                {
                    Debug.Log(hit.collider.gameObject);
                    isDragging = true;
                    offset = this.transform.position - cam.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 10.0f));
                }
            }
        }

        if(isDragging)
        {
            Vector3 curScreenPoint = new Vector3(inputPosition.x, inputPosition.y, 10.0f);
            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;

            // y軸とx軸の移動を制限
            curPosition.y = this.transform.position.y;
            curPosition.x = this.transform.position.x;

            if(curPosition.z > FRONT && !finish && attentionDrag)
            {
                CleanStep1();
            }

            if(curPosition.z < BACK && finish)
            {
                CleanStep5();
            }

            this.transform.position = curPosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    IEnumerator Finish()
    {
        //2秒まつ
        btn1.interactable = false;
        btn2.interactable = false;
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("Cleanliness", 100);
        PlayerPrefs.SetInt("SceneNo", HOME);
        PlayerPrefs.Save();
        SceneManager.LoadScene("home");
        Change_Emotion.isCleanFinishActive = true;
        gameData.firsttime_clean = true;
    }

    void CleanStep1()
    {
        Debug.Log("step1");
        isDragging = false;
        arrow.SetActive(false);
        setinst.SettingInstruction(text2);
        attentionDrag = false;
        // wirobj.transform.parent = null;
    }

    void CleanStep5()
    {
        Debug.Log("step5");
        //掃除完了
        isDragging = false;
        setinst.SettingInstruction(text6);
        StartCoroutine(Finish());
    }
}

// using UnityEngine;

// public class Drag_Drawer : MonoBehaviour
// {
//     public Camera camera;
//     private bool isDragging = false;
//     private Vector3 offset;

//     void Update()
//     {
//         Vector3 inputPosition;
//         if (Input.touchCount > 0)
//         {
//             inputPosition = Input.GetTouch(0).position;
//         }
//         else
//         {
//             inputPosition = Input.mousePosition;
//         }

//         if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
//         {
//             RaycastHit hit;
//             Ray ray = camera.ScreenPointToRay(inputPosition);

//             if (Physics.Raycast(ray, out hit))
//             {
//                 if (hit.collider.gameObject == this.gameObject)
//                 {
//                     isDragging = true;
//                     offset = this.transform.position - camera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 10.0f));
//                 }
//             }
//         }

//         if (isDragging)
//         {
//             Vector3 curScreenPoint = new Vector3(inputPosition.x, inputPosition.y, 10.0f);
//             Vector3 curPosition = camera.ScreenToWorldPoint(curScreenPoint) + offset;

//             // y軸とz軸の移動を制限
//             curPosition.y = this.transform.position.y;
//             curPosition.z = this.transform.position.z;

//             this.transform.position = curPosition;
//         }

//         if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
//         {
//             isDragging = false;
//         }
//     }
// }

