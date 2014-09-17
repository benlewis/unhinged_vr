using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public float distPerSecond = 0.2f;
	public float maxDistance = 1.0f;
	
	private float distanceMoved = 0.0f;
	private bool moving = false;
	
	public GameObject keyGear;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (keyGear.GetComponent<Gear>().IsSpinning()) {
			moving = true;
		}
		
		if (moving) {
			float deltay = distPerSecond * Time.deltaTime;
			distanceMoved += deltay;
			transform.Translate(0, deltay, 0);
			
			if (distanceMoved >= maxDistance)
				moving = false;
		}
	}
}
