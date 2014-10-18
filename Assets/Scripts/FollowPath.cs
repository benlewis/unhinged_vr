using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public int smoothnessSteps = 100;

	[HideInInspector]
	public Transform[] path;
	
	private float pathPosition = 0;
	
	[HideInInspector]
	public bool moving = false;
		
	private SmoothQuaternion smoothQ;
	
	// Use this for initialization
	void Start () {
		GameObject pathObject = GameObject.Find ("Path");
		List<Transform> transforms = new List<Transform>(pathObject.GetComponentsInChildren<Transform>());
		transforms.RemoveAt(0); // For some reason GetComponentsInChildren returns the main component. Delete it.
		path = transforms.ToArray();

		smoothQ = transform.rotation;
		smoothQ.Duration = 0.5f;
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
				
		smoothQ.Value = qToBeUsed;
		transform.rotation = smoothQ;
	}
}
