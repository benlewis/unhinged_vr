using UnityEngine;
using System.Collections;

public class MoveUpOnEnter : MonoBehaviour {

	private bool moving = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
			transform.position += Vector3.up * 0.01f;
	}
	
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<SelectObject>()) {
			// We collided with a player character. Attach them to the platform
			other.transform.parent = transform;
			other.GetComponent<CharacterController>().enabled = false;
			//other.GetComponent<CharacterMotor>().enabled = false;
			other.transform.localPosition = Vector3.up * 0.1f;
			
			// And start the ride
			moving = true;
		}
	}
}
