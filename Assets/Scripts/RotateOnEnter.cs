using UnityEngine;
using System.Collections;

public class RotateOnEnter : MonoBehaviour {

	public float rotateSpeed = 2.0f;
	private bool rotate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!rotate)
			transform.Rotate (0, rotateSpeed, 0);
	}
	
	void OnTriggerEnter(Collider other) {
		rotate = true;
	}
}
