using UnityEngine;
using System.Collections;

public class FreezeRelativeTorque : MonoBehaviour {

	private Vector3 zLock;
	private Vector3 positionLock;
	
	public float totalDeltaZ;
	private float zVelocity;
	private float deltaZAngle; 
	private float lastZAngle;
	private float timeSinceUpdate;
	
	// Use this for initialization
	void Start () {
		zLock = transform.localEulerAngles;
		positionLock = transform.position;
		lastZAngle = transform.localEulerAngles.z;
		deltaZAngle = 0.0f;
		timeSinceUpdate = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		deltaZAngle += Mathf.Abs(transform.localEulerAngles.z - lastZAngle);
		totalDeltaZ += deltaZAngle / Time.deltaTime / 10000.0f;
		timeSinceUpdate += Time.deltaTime;
		lastZAngle = transform.localEulerAngles.z;
		
		if (timeSinceUpdate > 0.2f) {
			zVelocity = deltaZAngle / timeSinceUpdate;
			timeSinceUpdate = 0.0f;
			deltaZAngle = 0.0f;
		}
	}
	
	void LateUpdate() {
		zLock.z = transform.localEulerAngles.z;
		transform.localEulerAngles = zLock;
		transform.position = positionLock;		
	}
}
