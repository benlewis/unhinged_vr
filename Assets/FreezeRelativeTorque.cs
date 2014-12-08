using UnityEngine;
using System.Collections;

public class FreezeRelativeTorque : MonoBehaviour {

	private Vector3 zLock;
	
	// Use this for initialization
	void Start () {
		zLock = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate() {
		zLock.z = transform.localEulerAngles.z;
		transform.localEulerAngles = zLock;
	}
}
