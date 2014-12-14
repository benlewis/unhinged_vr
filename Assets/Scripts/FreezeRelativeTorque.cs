using UnityEngine;
using System.Collections;

public class FreezeRelativeTorque : MonoBehaviour {

	private Vector3 zLock;
	private Vector3 positionLock;
	
	public float rotationSpeed = 0.0f;
	private float velocityAccum = 0.0f;
	private float interval = 5.0f;
	private float time = 0.0f;
	
	// Use this for initialization
	void Start () {
		zLock = transform.localEulerAngles;
		positionLock = transform.position;
		time = interval;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		velocityAccum += rigidbody.angularVelocity.magnitude;
		
		if (time <= 0.0f) {
			rotationSpeed = velocityAccum / (interval - time);
			time = interval;
			velocityAccum = 0.0f;
		}
	}
	
	void LateUpdate() {
		zLock.z = transform.localEulerAngles.z;
		transform.localEulerAngles = zLock;
		transform.position = positionLock;		
	}
}
