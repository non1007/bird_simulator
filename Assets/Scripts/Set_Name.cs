using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Set_Name : MonoBehaviour
{
    private TextMeshProUGUI nametmp;

    // Start is called before the first frame update
    void Start()
    {
        nametmp = this.GetComponent<TextMeshProUGUI>();
        nametmp.text = PlayerPrefs.GetString("Name", "ななし");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
