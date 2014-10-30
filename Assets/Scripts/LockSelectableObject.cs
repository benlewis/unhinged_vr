using UnityEngine;
using System.Collections;

public class LockSelectableObject : SelectableObject {

	public Door door1;
	public Door door2;
	
	public GameObject lockedPanel;
	public GameObject unlockedPanel;
	
	public SelectableObject partnerObject;

	private bool locked = true;
	
	public override void Select() {
		locked = false;
		SetSelectable(false);
		
		lockedPanel.SetActive(false);
		unlockedPanel.SetActive(true);
		
		//TODO: Play a click sound

		door1.OpenDoor();
		door2.OpenDoor();
		
		if (partnerObject)
			partnerObject.SetSelectable(partnerObject.IsSelectable());		
	}
	
	public bool DoorOpen() {	
		return !locked;
	}
	
	public override void TurnOnHighlight() {
		base.TurnOnHighlight();
		
		lockedPanel.SetActive(false);
		unlockedPanel.SetActive(true);
	}
	
	public override void TurnOffHighlight() {
		base.TurnOffHighlight();
		
		if (locked) {
			lockedPanel.SetActive(true);
			unlockedPanel.SetActive(false);
		}
	}
	
	public override bool IsSelectable() {
		return (locked);
	}	
}
