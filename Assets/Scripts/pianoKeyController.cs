using UnityEngine;
using System.Collections;

public class pianoKeyController : MonoBehaviour {

    public float tweenTime = 0.3f;
    public bool isKeyDown = false;

    void Update()
    {
        isKeyDown = (transform.localPosition.y < 0f);
    }

    void OnMouseDown()
    {
        play();
    }

    public void play()
    {
        LeanTween.moveLocalY(gameObject, -0.2f, tweenTime).setEase(LeanTweenType.easeOutExpo).setOnComplete(playFinished);
    }

    void playFinished()
    {
        LeanTween.moveLocalY(gameObject, 0f, tweenTime).setEase(LeanTweenType.easeInExpo);
    }
}
