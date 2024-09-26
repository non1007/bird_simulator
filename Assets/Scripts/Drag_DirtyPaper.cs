using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_DirtyPaper : MonoBehaviour
{                          
    public Camera cam;
    private bool isDragging;
    private Vector3 offset;
    private Vector3 inputPosition;
    // [SerializeField] GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        isDragging = false;
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
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject == this.gameObject && Drag_Drawer.attentionDrag == false)
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

            
            // Debug.Log(curPosition.y);

            curPosition.y = Mathf.Max(curPosition.y, 0.5f);

            this.transform.position = curPosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
