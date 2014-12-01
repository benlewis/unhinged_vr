using UnityEngine;
using System.Collections;

public class MoveOnKey : MonoBehaviour {

	float moveAmount = 0.02f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.D)) {
			transform.position -= Vector3.right * moveAmount;
		}
		
		if (Input.GetKey(KeyCode.A)) {
			transform.position += Vector3.right * moveAmount;
		}
		

	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log (rigidbody.angularVelocity);
		}
	}
}
