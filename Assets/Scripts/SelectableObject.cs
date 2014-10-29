using UnityEngine;
using System.Collections;

/*
	This class is abstract. All SelectableObjects
	Need to implement at least their own Select method
*/
public abstract class SelectableObject : MonoBehaviour {
	
	public Material highlightMaterial;
	
	
	protected bool isHighlighted = false;
	protected Material baseMaterial;
	
	public virtual void Start() {
		SetSelectable(IsSelectable());
	}

	public virtual void TurnOnHighlight() {
		if (isHighlighted)
			return;
		
		isHighlighted = true;
		
		if (highlightMaterial) {
			baseMaterial = renderer.material; 
			renderer.material = highlightMaterial;		
		}
	}
	
	public virtual void TurnOffHighlight() {
		if (!isHighlighted)
			return;
		
		isHighlighted = false;
		
		if (highlightMaterial) {
			renderer.material = baseMaterial;
		}
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
