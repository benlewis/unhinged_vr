using UnityEngine;
using System.Collections;

public class CrouchBoxTrigger : MonoBehaviour {

	[HideInInspector]
	public bool canStand = true;
	
	void OnTriggerEnter(Collider other) {
		if (other.name == "First Person Controller")
			return;
		canStand = false;
	}
	
	void OnTriggerExit(Collider other) {
		if (other.name == "First Person Controller")
			return;
		canStand = true;
	}
	
	void OnTriggerStay(Collider other) {
		if (other.name == "First Person Controller")
			return;
		canStand = false;
	}
}
