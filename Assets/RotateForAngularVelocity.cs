using UnityEngine;
using System.Collections;

public class RotateForAngularVelocity : MonoBehaviour {

	public Vector3 velocityToAchieve = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.angularVelocity != velocityToAchieve) {
			rigidbody.AddTorque(velocityToAchieve - rigidbody.angularVelocity);
		}
	}
}
