using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drag_Drawer : MonoBehaviour
{
    public Camera cam;
    public bool isDragging = false;
    public bool finish = false;
    private Vector3 offset;
    private Vector3 inputPosition;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text5;
    [SerializeField] GameObject text6;
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;

    public GameData gameData;    
    private const int HOME = 1;

    // [SerializeField]z
    // private GameObject wirobj;
    void Start()
    {
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
                if (hit.collider.gameObject == this.gameObject)
                {
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

            if(curPosition.z > 6.0f && finish == false)
            {
                isDragging = false;
                arrow.SetActive(false);
                text1.SetActive(false);
                text2.SetActive(true);

                // wirobj.transform.parent = null;
            }

            if(curPosition.z < 4.58f && finish == true)
            {
                //掃除完了
                isDragging = false;
                text5.SetActive(false);
                text6.SetActive(true);
                StartCoroutine(Finish());
            }

            this.transform.position = curPosition;
        }

        if (Input.GetMouseButtonUp(0))
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

