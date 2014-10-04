using UnityEngine;
using System.Collections;

public class PrizeSelectableObject : SelectableObject {

	public override void Select() {
		// Disappear
		gameObject.SetActive(false);
	}
}
