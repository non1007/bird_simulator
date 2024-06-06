using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Switch_Toggle : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private RectTransform handle;
    //[SerializeField] private bool onAwake;

    [NonSerialized] public bool Value; //script
    
    private float handlePosX;
    private Sequence sequence; //animation
    
    private static readonly Color OFF_BG_COLOR = new Color(0.92f, 0.92f, 0.92f);
    private static readonly Color ON_BG_COLOR = new Color(0.2f, 0.84f, 0.3f);

    private const float SWITCH_DURATION = 0.36f;
    [SerializeField] private GameObject obj;
    
    private void Start()
    {
        handlePosX = Mathf.Abs(handle.anchoredPosition.x);
        Value = obj.activeSelf;
        UpdateToggle(0);
    }

    public void SwitchToggle()
    {
        Value = !Value;
        if(Value)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
        UpdateToggle(SWITCH_DURATION);
    }

    private void UpdateToggle(float duration)
    {
        var bgColor = Value ? ON_BG_COLOR : OFF_BG_COLOR;
        var handleDestX = Value ? handlePosX : -handlePosX;

        sequence?.Complete();
        sequence = DOTween.Sequence();
        sequence.Append(backgroundImage.DOColor(bgColor, duration))
            .Join(handle.DOAnchorPosX(handleDestX, duration / 2));
    }
}