using UnityEngine;
using System.Collections;

public class RotateForAngularVelocity : MonoBehaviour {

	public Vector3 velocityToAchieve = Vector3.zero;

	private Vector3 zLock;

	// Use this for initialization
	void Start () {
		zLock = transform.localEulerAngles;
		Debug.Log ("Starts at " + zLock);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 localangularvelocity = transform.InverseTransformDirection(rigidbody.angularVelocity);
		if (localangularvelocity != velocityToAchieve) {
			rigidbody.AddRelativeTorque(velocityToAchieve - localangularvelocity);
		}
	}
	
	void LateUpdate() {
		zLock.z = transform.localEulerAngles.z;
		transform.localEulerAngles = zLock;
	}
}
