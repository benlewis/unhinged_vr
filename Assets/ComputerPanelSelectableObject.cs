using UnityEngine;
using System.Collections;

public class ComputerPanelSelectableObject : SelectableObject {

	public LaptopSelectableObject laptop;
	public GameObject objectToActivate; 
	private bool activated = false;
	
	public override void Select() {
		activated = true;
		laptop.Open();
		if (objectToActivate)
			objectToActivate.SetActive(true);
			
		SetSelectable();
	}
	
	public override bool IsSelectable() {
		return !activated;
	}
}
