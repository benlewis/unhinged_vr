using UnityEngine;
using System.Collections;

public class LaptopSelectableObject : SelectableObject {
	
	public GameObject itemToMove;
	public Transform laptopFold;
	
	private bool opened = false;
	private bool itemMoved  = false;
	
	public override void Select() {		
		itemToMove.GetComponent<Animator>().Play ("move_down");		
		itemMoved = true;
		SetSelectable();
	}
	
	public override bool IsSelectable() {
		return (opened && !itemMoved);
	}
	
	public void Open() {
		// Open the hinge, turn on highlight, play sound
		laptopFold.Rotate(250.0f - laptopFold.localEulerAngles.x, 0, 0);
		opened = true;
		audio.Play();
		SetSelectable();
	}
}
