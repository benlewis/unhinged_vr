using UnityEngine;
using System.Collections;

public class PegSelectableObject : SelectableObject {

	public override void Select() {
		// Call with true to look at inactive children
		Gear g = GetComponentsInChildren<Gear>(true)[0];
		g.AddToScene();
	}
}
