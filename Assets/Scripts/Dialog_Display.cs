using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ダイアログの表示設定
public class Dialog_Display : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private DialogDie_Animator dialog_die;
    [SerializeField]
    private DialogIll_Animator dialog_ill;
    [SerializeField]
    private DialogHospital_Animator dialog_hospital;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(animator.GetBool("IsLived")) && !(dialog_hospital.IsOpen))
        {
            dialog_die.Open();
        }

        if(animator.GetBool("IsIll") && !(dialog_hospital.IsOpen))
        {
            dialog_ill.Open();
        }
    }
}
