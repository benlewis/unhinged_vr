using UnityEngine;
using System.Collections;

public class LockSelectableObject : SelectableObject {

	public Door door1;
	public Door door2;

	private bool locked = true;
	
	public override void Select() {
		locked = false;
		SetSelectable(false);
		
		baseMaterial.SetColor("_Color", Color.green);

		door1.OpenDoor();
		door2.OpenDoor();		
	}
	
	public override bool IsSelectable() {
		return (locked);
	}	
}
