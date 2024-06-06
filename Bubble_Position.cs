using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Position : MonoBehaviour
{
    [SerializeField]
    private Transform ttfm;
    public Camera cam;


    private RectTransform tfm;
    public Vector3 offset = new Vector3(0f, 1.5f, 0f);

    void Start()
    {
        tfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        tfm.position = RectTransformUtility.WorldToScreenPoint(cam, ttfm.position + offset);
    }
}