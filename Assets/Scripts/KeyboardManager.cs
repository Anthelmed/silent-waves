using UnityEngine.UI;
using UnityEngine;

public class KeyboardManager : MonoBehaviour {

    public Button[] buttons;
    public pianoKeyController[] pianoKeysController;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            pianoKeysController[0].play();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            pianoKeysController[1].play();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            pianoKeysController[2].play();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            pianoKeysController[3].play();
        }
    }
}
