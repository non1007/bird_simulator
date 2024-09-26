using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Instruction : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;

    // Start is called before the first frame update

    void Start()
    {
        text1 = transform.Find("Instruction1").gameObject;
        text2 = transform.Find("Instruction2").gameObject;
        text3 = transform.Find("Instruction3").gameObject;
        text4 = transform.Find("Instruction4").gameObject;
        text5 = transform.Find("Instruction5").gameObject;
        text6 = transform.Find("Instruction6").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingInstruction(GameObject ontext)
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        ontext.SetActive(true);
    }
}
