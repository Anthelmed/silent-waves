using UnityEngine;

public class PianoKeysManager : MonoBehaviour
{

    public GameObject waves;
    public DisplacementController wavesController;
    public float tweenTime = 0f;
    public GameObject[] pianoKeys;
    public PianoKeyController[] pianoKeysController;

    void Update ()
    {
        checkPianoKeys();
    }

    void checkPianoKeys()
    {
        float newDisplacementValue = 0f;

        for (int i = 0; i < pianoKeys.Length; i++)
        {
            if (pianoKeysController[i].isKeyDown)
            {
                float result = Map(0f, -0.2f, 0f, 0.25f, pianoKeys[i].transform.localPosition.y);
                newDisplacementValue += result;
            }
        }

        float currentDisplacement = wavesController.getDisplacementScale();
        LeanTween.value(gameObject, updateDisplacement, currentDisplacement, newDisplacementValue, tweenTime).setEase(LeanTweenType.linear);
    }

    void updateDisplacement(float val, float ratio)
    {
        wavesController.setDisplacementScale(val);
    }

    public float Map(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
