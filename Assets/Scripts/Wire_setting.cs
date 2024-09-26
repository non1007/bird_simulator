using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_setting : MonoBehaviour
{
    [SerializeField] GameObject text5;
    [SerializeField]
    private GameObject parentobj;
    [SerializeField]
    private GameObject newobj;
    [SerializeField]
    private GameObject oldobj;
    [SerializeField] GameObject drawer;

    private const float OFFSET_WIDTH = 0.1f;
    public const float OFFSET_HIGHT = 0.5f;

    public Setting_Instruction setinst;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) //ぶつかったら消える命令文開始
    {
        if(collision.gameObject.CompareTag("New"))
        {
            NewPaper_inbox new_script; //呼ぶスクリプトにあだなつける
            GameObject objnew = GameObject.Find("Newpaper"); //Playerっていうオブジェクトを探す
            new_script = objnew.GetComponent<NewPaper_inbox>(); //付いているスクリプトを取得
            
            if(!(new_script.firsttime)) //トレイ前のペーパにあたっても表示されるので
            {

                Vector3 posi = this.transform.position;
                Vector3 drawerposi = drawer.transform.position;

                if(posi.x > drawerposi.x - OFFSET_WIDTH && posi.x < drawerposi.x + OFFSET_WIDTH)
                {
                    if(posi.z > drawerposi.z - OFFSET_WIDTH && posi.z < drawerposi.z + OFFSET_WIDTH)
                    {
                        if(posi.y > 0f && posi.y < OFFSET_HIGHT)
                        {
                            CleanStep4();
                        }
                    }
                }

            }
        }
    }

    void CleanStep4()
    {
        Debug.Log("step4");
        setinst.SettingInstruction(text5);

        Drag_Drawer.attentionDrag = true;
        Drag_Drawer.finish = true;

        newobj.transform.parent = parentobj.transform;
        oldobj.transform.parent = null;
        this.transform.parent = parentobj.transform;
    }
}