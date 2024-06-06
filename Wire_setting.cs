using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_setting : MonoBehaviour
{
    [SerializeField] GameObject text4;
    [SerializeField] GameObject text5;
    [SerializeField]
    private GameObject parentobj;
    [SerializeField]
    private GameObject newobj;
    [SerializeField]
    private GameObject oldobj;

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

                if(posi.x < -5.0f && posi.x >-5.1f)
                {
                    if(posi.z < 6.1f && posi.z > 6.0f)
                    {
                        if(posi.y > 0f && posi.y < 0.2f)
                        {
                            Drag_Drawer drawer_script; //呼ぶスクリプトにあだなつける
                            GameObject objdrw = GameObject.Find("Drawer"); //Playerっていうオブジェクトを探す
                            drawer_script = objdrw.GetComponent<Drag_Drawer>(); //付いているスクリプトを取得
                            
                            text4.SetActive(false);
                            text5.SetActive(true);
                            // drawer_script.isDragging = true;
                            drawer_script.finish = true;

                            newobj.transform.parent = parentobj.transform;
                            oldobj.transform.parent = null;
                            this.transform.parent = parentobj.transform;
                        }
                    }
                }

            }
        }
    }
}