using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyPaper_inbox : MonoBehaviour
{
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    private bool firsttime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.position;
        
        if(firsttime)
        {
            if(posi.x < -3.3f && posi.x >-3.9f)
            {
                if(posi.z < 6.3f && posi.z > 5.7f)
                {
                    if(posi.y > 0f && posi.y < 0.5f)
                    {
                        text2.SetActive(false);
                        text3.SetActive(true);
                        firsttime = false;
                    }
                }
            }
        }

    }
}
