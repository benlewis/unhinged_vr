using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class SelectObject : MonoBehaviour {

	public float range  = 5.0f;
	public AudioClip highlightSound;
	public AudioClip selectSound;

	[HideInInspector]
	public GameObject selectedObject = null;

	void Start () {
		Screen.lockCursor = true;
	}
	
	void Update () {
		// Highlight any selectable objects we are facing
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit;
		LayerMask layer = LayerMask.GetMask("Selectable");
		
		GameObject newSelectedObject = null;
		// if (Physics.Raycast(ray, out hit, range, layer))
		if (Physics.SphereCast(ray, 0.5f, out hit, range, layer)) {
			newSelectedObject = hit.collider.gameObject;
		}
				
		if (newSelectedObject != selectedObject) {
			if (highlightSound)
				audio.PlayOneShot(highlightSound);
		
			if (selectedObject != null) {
				selectedObject.GetComponent<SelectableObject>().TurnOffHighlight();
			}
			
			selectedObject = newSelectedObject;
			
			if (selectedObject != null) {
				selectedObject.GetComponent<SelectableObject>().TurnOnHighlight();
			}
		}
		
		if (Input.GetButtonDown("Fire1") && selectedObject != null) {
			if (selectSound)
				audio.PlayOneShot(selectSound);
								
			selectedObject.GetComponent<SelectableObject>().Select();
		}
	}
}
