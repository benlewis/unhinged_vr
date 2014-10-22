using UnityEngine;
using System.Collections;

public class FadeIfClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 cameraPosition = Camera.main.transform.position;
//		float sqrDistance = Vector3.Dot(cameraPosition, transform.position);
//		if (sqrDistance < 4) {
//			TextMesh mesh = GetComponent<TextMesh>();
//			mesh.color = Color.clear;
//		}
	}
	
	public void OnTriggerEnter(Collider other) {
		GetComponent<TextMesh>().color = Color.clear;
	}
	
	public void OnTriggerExit(Collider other) {
		GetComponent<TextMesh>().color = Color.white;
	}
}
