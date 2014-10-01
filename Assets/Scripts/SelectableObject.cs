using UnityEngine;
using System.Collections;

public class SelectableObject : MonoBehaviour {

	// This script should be a Component of this GameObject
	// It is responsible for handling the SelectEvent method 
	public MonoBehaviour objectScript;
	
	public Material highlightMaterial;
	
	
	private bool isHighlighted = false;
	private Material baseMaterial;
	
	public void Start() {

	}

	public void TurnOnHighlight() {
		if (isHighlighted)
			return;
		
		isHighlighted = true;
		baseMaterial = renderer.material; 
		renderer.material = highlightMaterial;		
	}
	
	public void TurnOffHighlight() {
		if (!isHighlighted)
			return;
		
		isHighlighted = false;
		renderer.material = baseMaterial;
	}
	
	public void Select() {
		// Each SelectableObject has their own method for handling how a "Select" call should happen
		
		// This will call that method. Ideally we could use inheritance rather than SendMessage, but not a big deal.
		objectScript.SendMessage("SelectEvent");
	}
}
