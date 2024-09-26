using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//汚れた紙が箱の中に入る判定
public class DirtyPaper_inbox : MonoBehaviour
{
    [SerializeField] GameObject text3;
    private bool firsttime;

    private const float LEFT_X = -3.3f;
    private const float RIGHT_X = -3.9f;
    private const float TOP_Y = 0.5f;
    private const float BOTTOM_Y = 0f;
    private const float TOP_Z = 6.3f;
    private const float BOTTOM_Z = 5.7f;

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
        
        if(firsttime)
        {
            if(posi.x < LEFT_X && posi.x > RIGHT_X)
            {
                if(posi.z < TOP_Z && posi.z > BOTTOM_Z)
                {
                    if(posi.y > BOTTOM_Y && posi.y < TOP_Y)
                    {
                        CleanStep2();
                    }
                }
            }
        }
    }

    void CleanStep2()
    {
        Debug.Log("step2");
        setinst.SettingInstruction(text3);
        firsttime = false;
    }
}
