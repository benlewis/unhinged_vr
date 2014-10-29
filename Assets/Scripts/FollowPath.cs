using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public int smoothnessSteps = 100;

	private Transform[] path = null;
	private string level = null;
	
	[HideInInspector]
	public bool inPlatform = false;
		
	private float pathPosition;
	
	private SmoothQuaternion smoothQ;
	private Quaternion startingRotation;
	
	// Use this for initialization
	void Start () {
		smoothQ = transform.rotation;
		startingRotation = transform.rotation;
		smoothQ.Duration = 0.5f;
	}
	
	public void SetPath(GameObject pathObject) {
		List<Transform> transforms = new List<Transform>(pathObject.GetComponentsInChildren<Transform>());
		transforms.RemoveAt(0); // For some reason GetComponentsInChildren returns the main component. Delete it.
		path = transforms.ToArray();
	}
	
	public void SetLevel(string levelName) {
		level = levelName;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetButtonDown("Fire1")) {
//			moving = !moving;
//		}
		
		// Only move once all the pieces are in place
		if (!inPlatform || path == null || level == null)
			return;
				    
		Quaternion qToBeUsed = Quaternion.identity;
		transform.position = Spline.MoveOnPath(path, transform.position, ref pathPosition, ref qToBeUsed, 
			maxSpeed, smoothnessSteps, EasingType.Quadratic, 
			true, // Ease In
			true // Ease Out
			);
		
		
		if (transform.position == path[path.Length - 1].position)
			Application.LoadLevel(level);
		
		Quaternion newRotation = qToBeUsed;
		qToBeUsed.y -= startingRotation.y;		
		smoothQ.Value = newRotation;
		transform.rotation = smoothQ;
	}
}
