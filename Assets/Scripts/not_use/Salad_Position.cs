using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad_Position : MonoBehaviour
{
    [SerializeField] GameObject pet;
    Vector3 petposi;
    Vector3 petangle;
    Quaternion petrot;

    Vector3 saladposi;
    Vector3 saladangle;
    Quaternion saladrot;

    float distance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        petposi = pet.transform.position; //位置
        petrot = pet.transform.rotation; //回転角
        petangle = pet.transform.eulerAngles; //オイラー角

        saladposi = this.transform.position; //位置
        saladrot = this.transform.rotation; //回転角
        saladangle = this.transform.eulerAngles; //オイラー角

        saladposi = petposi + petrot * Vector3.forward * distance; //(0,0,1)*distance
        saladrot = Quaternion.LookRotation(petposi - saladposi); //レタスの向き
        saladangle = new Vector3(saladangle.x + 90, saladangle.y + 180, 0);

    }
}