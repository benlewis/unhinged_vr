using UnityEngine;
using System.Collections;
using InControl;

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
		if (Physics.SphereCast(ray, 0.5f, out hit, range, layer)) {
			newSelectedObject = hit.collider.gameObject;
		}
				
		if (newSelectedObject != selectedObject) {			
			if (selectedObject != null) {
				selectedObject.GetComponent<SelectableObject>().TurnOffHighlight();
			}
			
			selectedObject = newSelectedObject;
			
			if (selectedObject != null) {
				if (highlightSound)
					audio.PlayOneShot(highlightSound);
				
				selectedObject.GetComponent<SelectableObject>().TurnOnHighlight();
			}
		}
		
		InputDevice input = InputManager.ActiveDevice;
		
		if ((input.Action1.WasPressed) && selectedObject != null) {
			if (selectSound)
				audio.PlayOneShot(selectSound);
								
			selectedObject.GetComponent<SelectableObject>().Select();
		}
	}
}
