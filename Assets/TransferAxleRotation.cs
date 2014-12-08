using UnityEngine;
using System.Collections;

public class TransferAxleRotation : MonoBehaviour {

	public Rigidbody transferFrom;
	public Rigidbody transferTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 velocityNeeded = transferFrom.angularVelocity - transferTo.angularVelocity;
		transferTo.AddTorque(velocityNeeded);
	}
}
