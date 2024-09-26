using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPaper_inbox : MonoBehaviour
{
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject drawer;
    public bool firsttime;

    private const float OFFSET_WIDTH = 0.1f;
    public const float OFFSET_HIGHT = 0.2f;

    public Setting_Instruction setinst;

    // Start is called before the first frame update
    void Start()
    {
        firsttime = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.position;
        Vector3 drawerposi = drawer.transform.position;
        //Debug.Log(posi);
        //Debug.Log(drawerposi);
                
        if(firsttime && Drag_Drawer.attentionDrag == false)
        {
            if(posi.x > drawerposi.x - OFFSET_WIDTH && posi.x < drawerposi.x + OFFSET_WIDTH)
            {
                if(posi.z > drawerposi.z - OFFSET_WIDTH && posi.z < drawerposi.z + OFFSET_WIDTH)
                {
                    if(posi.y > 0f && posi.y < OFFSET_HIGHT)
                    {
                        CleanStep3();
                    }
                }
            }
        }
    }

    void CleanStep3()
    {
        Debug.Log("step3");
        setinst.SettingInstruction(text4);
        firsttime = false;
    }
}

