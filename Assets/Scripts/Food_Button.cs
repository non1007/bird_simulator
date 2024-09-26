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

    [SerializeField]
    Button clickbtn;
    [SerializeField]
    Button cleanbtn;

    void Start()
    {
        //非表示
        food.SetActive(false);

        animator = bird.GetComponent<Animator>();

        btn = GetComponent<Button>();
    }

    void Update()
    {
        
    }

    IEnumerator Eat()
    {
        while(food.activeSelf)
        {
            if (Vector3.Distance(bird.transform.position, food.transform.position) < 1.0f)
            {
                // 鳥がfoodの近くにいる場合のみ食べる
                animator.SetBool("IsEating", true);
                yield return new WaitForSeconds(2);
                food.SetActive(false);
                animator.SetBool("IsEating", false);
                statusobj.GetComponent<Hunger_Status>().CountHunger();
                btn.interactable = true;
                clickbtn.interactable = true;
                cleanbtn.interactable = true;
                break;
            }
            else
            {
                //鳥が近くにいない
                yield return null; // 次のフレームまで待機
            }
        }
    }

    public void OnButton()
    {
        StartCoroutine(Eat());
    }
}
