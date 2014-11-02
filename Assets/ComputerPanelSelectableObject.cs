using UnityEngine;
using System.Collections;

public class ComputerPanelSelectableObject : SelectableObject {

	public LaptopSelectableObject laptop;
	public GameObject objectToActivate; 

	public override void Select() {
		laptop.Open();
		if (objectToActivate)
			objectToActivate.SetActive(true);
	}
}
