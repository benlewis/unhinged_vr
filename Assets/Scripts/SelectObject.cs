using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour {

	public float range  = 5.0f;

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
			if (selectedObject != null) {
				selectedObject.GetComponent<SelectableObject>().TurnOffHighlight();
			}
			
			selectedObject = newSelectedObject;
			
			if (selectedObject != null) {
				selectedObject.GetComponent<SelectableObject>().TurnOnHighlight();
			}
		}
		
		if (Input.GetButtonDown("Fire1") && selectedObject != null) {				
			selectedObject.GetComponent<SelectableObject>().Select();
		}
	}
}
