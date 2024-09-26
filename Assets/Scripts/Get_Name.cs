using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Get_Name : MonoBehaviour {

    //オブジェクトと結びつける
    private TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを扱えるようにする
        input = this.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputText()
    {
        PlayerPrefs.SetString("Name", input.text);
        PlayerPrefs.Save();
    }
}