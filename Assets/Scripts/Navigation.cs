using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;
using UnityEngine.UI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class Navigation : MonoBehaviour
{
    public Transform central;
   	public BudgerigarCharacter budgerigarCharacter;
    
    public GameObject food;
    public food_btn fbtn;
    public bool isEaten = false;
    
    [SerializeField]
    Button foodbtn;
    [SerializeField]
    Button cleanbtn;

    [SerializeField]
    Button clickbtn;


    private NavMeshAgent agent;
    [SerializeField] float radius = 3;
    [SerializeField] float waitTime = 5;
    [SerializeField] float time = 0;

    Animator anim;

    Vector3 pos;

    public static bool isManualMove = false;
    private Vector3 lastManualPosition;
    private Quaternion lastManualRotation;

    void Start()
    {
        budgerigarCharacter = GetComponent<BudgerigarCharacter>();

        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        agent.autoBraking = false;
        //NavMeshAgentで回転をしないようにする
        agent.updateRotation = false;

        GotoNextPoint();
    }

    void Update()
    {
        if(!(anim.GetBool("IsLived")) || anim.GetBool("IsIll"))
        {
            Stop();
        }
        else if(!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            if(isEaten)
            {
                StopEat();
            }
            else if(!isManualMove)
            {
                StopHere();
            }
            else
            {
                StopMove();
            }
            
        }

    }

    public void GotoNextPoint()
    {
        if(isManualMove)
        {
            return;
        }

        agent.isStopped = false;
        budgerigarCharacter.HopForward();
        budgerigarCharacter.forwardSpeed = 0.3f;

        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        pos = central.position;
        pos.x += posX;
        pos.z += posZ;

        if(isEaten)
        {
            pos = food.transform.position;
        }

        //Y軸だけ変更しない目標地点
        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);

        //Y軸だけ変更しない目標地点から現在地を引いて向きを割り出す
        Quaternion rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
        //このオブジェクトの向きを替える
        transform.rotation = rotation;

        agent.destination = pos;
    }

    void StopHere()
    {
        agent.isStopped = true;
        time += Time.deltaTime;
        budgerigarCharacter.forwardSpeed = 0f;

        if (time > waitTime)
        {
            GotoNextPoint();
            time = 0;
        }
    }

    void StopEat()
    {
        agent.isStopped = true;
        budgerigarCharacter.forwardSpeed = 0f;
           
        fbtn.OnButton();

        GotoNextPoint();
        time = 0;
        isEaten = false;
    }

    void StopMove()
    {
        agent.isStopped = true;
        budgerigarCharacter.forwardSpeed = 0f;
        if(Input.GetMouseButtonDown(0))
        {
            agent.isStopped = false;
            budgerigarCharacter.HopForward();
            budgerigarCharacter.forwardSpeed = 0.3f;
        }
    }

    void Stop()
    {
        agent.isStopped = true;
        budgerigarCharacter.forwardSpeed = 0f;

        foodbtn.interactable = false;
        cleanbtn.interactable = false;
    }

    public void IsEaten()
    {
        isEaten = true;
        food.SetActive(true);
        foodbtn.interactable = false;
        clickbtn.interactable = false;
        cleanbtn.interactable = false;
    }

    public void MoveToClickPosition(Vector3 position)
    {
        agent.isStopped = false;
        budgerigarCharacter.HopForward();
        budgerigarCharacter.forwardSpeed = 0.3f;

        Vector3 direction = new Vector3(position.x, transform.position.y, position.z);
        Quaternion rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
        transform.rotation = rotation;

        agent.destination = position;
    }
    
    public void OutMove()
    {
        // 手動移動終了時の位置と回転を保持
        lastManualPosition = transform.position;
        lastManualRotation = transform.rotation;
        GotoNextPoint();
    }
}