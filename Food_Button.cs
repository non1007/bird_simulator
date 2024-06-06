using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class food_btn : MonoBehaviour
{
    public GameObject food;
    [SerializeField] GameObject bird;
    private Animator animator;

    public GameObject statusobj;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        //非表示
        food.SetActive(false);

        animator = bird.GetComponent<Animator>();

        btn = GetComponent<Button>();
        
        // statusobj = GameObject.Find("Canvas/FoodButton").GetComponent<Status>();
        // if (status == null)
        // {
        //     Debug.LogError("Status component not found on the object.");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Eat()
    {
        if(food.activeSelf)
        {
            //Eat状態に遷移
            //animator.SetTrigger("EatTrigger");
            animator.SetBool("IsEating", true);

            //2秒まつ
            yield return new WaitForSeconds(2);

            //ボタン押せないようにしたい

            food.SetActive(false);
            animator.SetBool("IsEating", false);
            statusobj.GetComponent<Hunger_Status>().CountHunger();
            btn.interactable = true;
        }        
    }

    public void OnButton()
    {
        StartCoroutine(Eat());
    }


}
