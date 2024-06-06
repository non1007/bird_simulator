using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Wire : MonoBehaviour
{                          
    public Camera cam;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 inputPosition;
    // [SerializeField] GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputPosition = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(inputPosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == this.gameObject)
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

            
            Debug.Log(curPosition.y);

            curPosition.y = Mathf.Max(curPosition.y, 0.5f);
            // if(curPosition.y < 1.0f)
            // {
            //     Debug.Log(curPosition.y);
            //     //z軸とx軸の移動を制限
            //     curPosition.z = this.transform.position.z;
            //     curPosition.x = this.transform.position.x;

            //     // arrow.SetActive(false);
            // }
            
            // if(curPosition.y >= 1.0f)
            // {
            //     //y軸とz軸の移動を制限
            //     curPosition.y = this.transform.position.y;
            //     curPosition.z = this.transform.position.z;


            //     // if(curPosition.x < 6.0f)
            //     // {
            //     //     isDragging = false;
            //     // }
            // }

            this.transform.position = curPosition;

            // // 親オブジェクトのローカル座標に変換
            // curPosition = transform.parent.InverseTransformPoint(curPosition);

            // this.transform.localPosition = curPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
