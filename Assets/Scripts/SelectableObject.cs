using UnityEngine;
using System.Collections;

/*
	This class is abstract. All SelectableObjects
	Need to implement at least their own Select method
*/

public abstract class SelectableObject : MonoBehaviour {
	
	public GameObject[] parts;	
	public Material highlightMaterial;
	public Color highlightColor;
	
	protected bool isHighlighted = false;
	protected Material[] baseMaterials;
	protected Color[] baseColors;	
	
	public virtual void Start() {
		SetSelectable();
		
		baseColors = new Color[parts.Length];
		baseMaterials = new Material[parts.Length];
		for (int i = 0; i < parts.Length; i++) {
			baseColors[i] = parts[i].renderer.material.color;
			baseMaterials[i] = parts[i].renderer.material;
		}		
	}

	public virtual void TurnOnHighlight() {
		if (isHighlighted)
			return;
		
		isHighlighted = true;
		
		for (int i = 0; i < parts.Length; i++) {
			if (highlightMaterial != null)
				parts[i].renderer.material = highlightMaterial;
			else 
				parts[i].renderer.material.color = highlightColor;
		}
	}
	
	public virtual void TurnOffHighlight() {
		if (!isHighlighted)
			return;
		
		isHighlighted = false;

		for (int i = 0; i < parts.Length; i++) {
			if (highlightMaterial != null)
				parts[i].renderer.material = baseMaterials[i];
			else
				parts[i].renderer.material.color = baseColors[i];
		}			
	}
	
	public void SetSelectable() {
		if (IsSelectable())
			gameObject.layer = LayerMask.NameToLayer("Selectable");
		else
			gameObject.layer = LayerMask.NameToLayer("Default");
				
	}
	
	public abstract void Select();
	public virtual bool IsSelectable() {
		return true;
	}
}
