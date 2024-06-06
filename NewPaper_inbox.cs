using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPaper_inbox : MonoBehaviour
{
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject drawer;
    public bool firsttime = true;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.position;
        Vector3 drawerposi = drawer.transform.position;
        //Debug.Log(posi);
        //Debug.Log(drawerposi);
                
        if(firsttime)
        {
            if(posi.x > drawerposi.x - 0.1f && posi.x < drawerposi.x + 0.1f)
            {
                if(posi.z > drawerposi.z - 0.1f && posi.z < drawerposi.z + 0.1f)
                {
                    if(posi.y > 0f && posi.y < 0.2f)
                    {
                        text3.SetActive(false);
                        text4.SetActive(true);
                        firsttime = false;
                    }
                }
            }
        }

    }
}

