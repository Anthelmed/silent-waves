using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour,
    IPointerDownHandler, 
    IPointerUpHandler
{

    public GameObject tweenImage;
    public float tweenTime = 0.3f;

    public bool isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        LeanTween.cancel(tweenImage);
        LeanTween.moveLocalX(tweenImage, 3f, tweenTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalY(tweenImage, -3f, tweenTime).setEase(LeanTweenType.easeOutExpo);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        LeanTween.cancel(tweenImage);
        LeanTween.moveLocalX(tweenImage, 0f, tweenTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalY(tweenImage, 0f, tweenTime).setEase(LeanTweenType.easeOutExpo);
    }
}
