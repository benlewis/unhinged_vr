using UnityEngine;
using System.Collections;

public class EnterPlatformTrigger : MonoBehaviour {

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<SelectObject>()) {
			// We collided with a player character. Attach them to the platform
			GameObject platform = transform.parent.gameObject;
			other.transform.parent = platform.transform;
			other.GetComponent<CharacterController>().enabled = false;
			other.transform.localPosition = Vector3.up * 0.5f;
			
			// And start the ride
			platform.GetComponent<FollowPath>().moving = true;
		}
	}
}
