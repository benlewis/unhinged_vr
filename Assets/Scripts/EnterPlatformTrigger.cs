using UnityEngine;
using System.Collections;

public class EnterPlatformTrigger : MonoBehaviour {

	public GameObject platform;

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<SelectObject>()) {
			// We collided with a player character. Attach them to the platform
			other.transform.parent = platform.transform;
			other.GetComponent<CharacterController>().enabled = false;
			other.GetComponent<CharacterMotor>().enabled = false;
			other.transform.localPosition = Vector3.up * 0.1f;
			
			// And start the ride
			platform.GetComponent<FollowPath>().inPlatform = true;
		}
	}
}
