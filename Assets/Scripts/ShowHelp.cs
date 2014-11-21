using UnityEngine;
using System.Collections;
using InControl;

public class ShowHelp : MonoBehaviour {

	public GameObject helpScreen;
	
	// Update is called once per frame
	void Update () {
		InputDevice input = InputManager.ActiveDevice;	
		if (input.Action3.WasPressed)
			helpScreen.SetActive(!helpScreen.activeSelf);		
	}
}
