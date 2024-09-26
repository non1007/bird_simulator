using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//インコが生きている場合、音を再生
public class Setting_Audio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if(animator.GetBool("IsLived"))
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
