using UnityEngine;
using System.Collections;

public class LaptopSelectableObject : SelectableObject {
	
	public GameObject[] parts;	
	public GameObject itemToMove;
	public LockSelectableObject partnerLock; 
	
	private Color[] baseColors;	
	private bool opened = false;

	public override void Start() {
		base.Start ();
		
		baseColors = new Color[parts.Length];
		for (int i = 0; i < parts.Length; i++) {
			baseColors[i] = parts[i].renderer.material.color;
		}
	}
	
	public override void Select() {
		opened = true;
		itemToMove.GetComponent<Animator>().Play ("move_down");		
	}
	
	public override bool IsSelectable() {
		return (!opened && partnerLock.DoorOpen());
	}
	
	public override void TurnOnHighlight() {
		base.TurnOnHighlight();
		
		for (int i = 0; i < parts.Length; i++) {
			parts[i].renderer.material.color = Color.green;
		}
	}
	
	public override void TurnOffHighlight() {
		base.TurnOffHighlight();
		
		for (int i = 0; i < parts.Length; i++) {
			parts[i].renderer.material.color = baseColors[i];
		}
	}
}
