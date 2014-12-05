using UnityEngine;
using System.Collections;
using InControl;

public class ICFPSInputController : MonoBehaviour {

	public GameObject player;
	private CharacterMotorC motor;
	
	public bool useHMD = false;
	public OVRCameraRig cameraController = null; 
	
	public bool defaultRunning = false;
	
	private float yRotation = 0.0f;

	// Use this for initialization
	public void Awake () {
		motor = player.GetComponent<CharacterMotorC>();

		if (useHMD && cameraController == null)
			Debug.LogWarning ("useHMD turned on without camera rig");
	}
	
	// Update is called once per frame
	public void Update () {
		InputDevice input = InputManager.ActiveDevice;		
		
		if (cameraController) {
			if (input.Action4.WasPressed)
				ResetOrientation();
				
			if (input.LeftBumper.WasPressed)
				yRotation -= 45.0f;
	
			if (input.RightBumper.WasPressed)
				yRotation += 45.0f;
				
			transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
		}
					
		// Get the input vector from keyboard or analog stick
		var directionVector = new Vector3(input.LeftStickX, 0, input.LeftStickY);
		
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			var directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}
		
		// Apply the direction to the CharacterMotor
		Quaternion rotation = transform.rotation;
		
		if (useHMD) {
			float hmdY = cameraController.centerEyeAnchor.localRotation.eulerAngles.y;
			rotation *= Quaternion.Euler(0.0f, hmdY, 0.0f);
		}
		
		if (input.LeftTrigger)
			motor.isRunning = !defaultRunning;
		else
			motor.isRunning = defaultRunning;
		
		motor.inputMoveDirection = rotation * directionVector;
		// motor.inputJump = Input.GetButton("Jump");
	}

	public void ResetOrientation() {
		yRotation = 0.0f;
	}
}