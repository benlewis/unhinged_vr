using UnityEngine;
using System.Collections;

/*
	This class is abstract. All SelectableObjects
	Need to implement at least their own Select method
*/
public abstract class SelectableObject : MonoBehaviour {
	
	public Material highlightMaterial;
	
	
	private bool isHighlighted = false;
	protected Material baseMaterial;
	
	public void Start() {
		SetSelectable(IsSelectable());
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
	
	public void SetSelectable(bool isSelectable) {
		if (isSelectable)
			gameObject.layer = LayerMask.NameToLayer("Selectable");
		else
			gameObject.layer = LayerMask.NameToLayer("Default");
				
	}
	
	public abstract void Select();
	public virtual bool IsSelectable() {
		return true;
	}
}
