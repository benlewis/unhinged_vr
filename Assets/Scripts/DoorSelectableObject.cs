using UnityEngine;
using System.Collections;

public class DoorSelectableObject : SelectableObject {

	private bool open = false;

	
	public override void Select() {
		open = true;
		hingeJoint.useMotor = true;
		SetSelectable(false);
	}
	
	public override bool IsSelectable() {
		return (!open);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
