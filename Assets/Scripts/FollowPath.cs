﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public int smoothnessSteps = 100;

	[HideInInspector]
	public Transform[] path;
	
	private float pathPosition = 0;
	
	private bool moving = false;
	
	private int rotates = 0;
	private float rotationDirection = 0.1f;
	private int maxRotates = 50;
	
	private SmoothQuaternion smoothQ;
	
	// Use this for initialization
	void Start () {
		GameObject pathObject = GameObject.Find ("Path");
		List<Transform> transforms = new List<Transform>(pathObject.GetComponentsInChildren<Transform>());
		transforms.RemoveAt(0); // For some reason GetComponentsInChildren returns the main component. Delete it.
		//transforms.Insert(0, transform); // Put our current position at the start
		path = transforms.ToArray();
		foreach (Transform t in path) {
			// Debug.Log (t);
		}
		
		smoothQ = transform.rotation;
		smoothQ.Duration = 0.5f;
	}
	
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<SelectObject>()) {
			// We collided with a player character. Attach them to the platform
			other.transform.parent = transform;
			other.GetComponent<CharacterController>().enabled = false;
			other.transform.localPosition = Vector3.up * 0.5f;
			
			// And start the ride
			moving = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetButtonDown("Fire1")) {
//			moving = !moving;
//		}
		
		if (!moving)
			return;
				    
		Quaternion qToBeUsed = Quaternion.identity;
		transform.position = Spline.MoveOnPath(path, transform.position, ref pathPosition, ref qToBeUsed, 
			maxSpeed, smoothnessSteps, EasingType.Quadratic, 
			true, // Ease In
			true // Ease Out
			);
		
		
		if (transform.position == path[path.Length - 1].position)
			Application.LoadLevel("room");
				
		Debug.Log (pathPosition);		
		// Rotate to the next point
		//targetRotation = Quaternion.LookRotation (target.position - transform.position);
		//transform.rotation = Quaternion.Lerp (transform.rotation, qToBeUsed, 0.5f);
		smoothQ.Value = qToBeUsed;
		transform.rotation = smoothQ;
		//transform.rotation = qToBeUsed;	
		//transform.Rotate (0,0, 2);
		
//		transform.Rotate (0,0, rotationDirection);
//		rotates += 1;
//		if (rotates == maxRotates) {
//			rotates = 0;
//			rotationDirection *= -1;
//		}
//		Debug.Log (transform.localRotation.z);
	}
}
