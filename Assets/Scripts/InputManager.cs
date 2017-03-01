using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public PianoKeyController[] pianoKeysController;
    public ButtonController[] buttonsController;

    private Transform clickedObject = null;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                clickedObject = hit.transform;
            } else
            {
                clickedObject = null;
            }
        } else
        {
            clickedObject = null;
        }

        if (Input.GetKey(KeyCode.F) || (clickedObject != null && clickedObject.tag == "PianoKey01") || buttonsController[0].isPressed)
        {
            pianoKeysController[0].setKeyDown();
        }
        else
        {
            pianoKeysController[0].setKeyUp();
        }

        if (Input.GetKey(KeyCode.G) || (clickedObject != null && clickedObject.tag == "PianoKey02") || buttonsController[1].isPressed)
        {
            pianoKeysController[1].setKeyDown();
        }
        else
        {
            pianoKeysController[1].setKeyUp();
        }

        if (Input.GetKey(KeyCode.H) || (clickedObject != null && clickedObject.tag == "PianoKey03") || buttonsController[2].isPressed)
        {
            pianoKeysController[2].setKeyDown();
        }
        else
        {
            pianoKeysController[2].setKeyUp();
        }

        if (Input.GetKey(KeyCode.J) || (clickedObject != null && clickedObject.tag == "PianoKey04") || buttonsController[3].isPressed)
        {
            pianoKeysController[3].setKeyDown();
        }
        else
        {
            pianoKeysController[3].setKeyUp();
        }
    }
}
