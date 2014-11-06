using UnityEngine;
using System.Collections;

public class HelpSelectableObject : SelectableObject {

	public GameObject textObject;
	
	public override void Select() {
		TextMesh[] otherTexts = textObject.transform.parent.GetComponentsInChildren<TextMesh>(true);
		Debug.Log("textobject is " + textObject.transform.gameObject.name);
		foreach (TextMesh tm in otherTexts) {
			Debug.Log("Found " + tm.name);
			tm.gameObject.SetActive(false);
		}
		textObject.SetActive(true);
		foreach (Transform t in textObject.transform) {
			t.gameObject.SetActive(true);
			foreach (Transform u in t.transform) {
				u.gameObject.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0.0f, 1.0f, 1.0f);
	}
}
