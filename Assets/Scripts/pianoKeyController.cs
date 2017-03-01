using UnityEngine;
using System.Collections;

public class PianoKeyController : MonoBehaviour {

    public float tweenTimeUp = 0.1f;
    public float tweenTimeDown = 0.3f;
    public bool isKeyDown = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        isKeyDown = (transform.localPosition.y < 0f);
    }

    public void setKeyDown()
    {
        if (isKeyDown)
        {
            return;
        }

        audioSource.Play();
        LeanTween.cancel(gameObject);
        LeanTween.moveLocalY(gameObject, -0.2f, tweenTimeDown).setEase(LeanTweenType.easeOutExpo);
    }

    public void setKeyUp()
    {
        if (!isKeyDown)
        {
            return;
        }

        audioSource.Stop();
        LeanTween.cancel(gameObject);
        LeanTween.moveLocalY(gameObject, 0, tweenTimeUp).setEase(LeanTweenType.easeOutExpo).setOnComplete(resetLocalPosition);
    }

    void resetLocalPosition(object myObj)
    {
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
