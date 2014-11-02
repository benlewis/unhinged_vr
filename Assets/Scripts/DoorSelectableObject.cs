using UnityEngine;
using System.Collections;

public class DoorSelectableObject : SelectableObject {

	private bool open = false;

	
	public override void Select() {
		open = true;
		hingeJoint.useMotor = true;
		SetSelectable();
	}
	
	public override bool IsSelectable() {
		return (!open);
	}
	
}
