using UnityEngine;
using System.Collections;

public class AxleSelectable : SelectableObject {

	private bool inUse = false;

	public override void Select() {
		GearSelectable gear = (GearSelectable) inventory.FirstOfType("GearSelectable");
		if (gear == null)
			throw new System.Exception("Selected axle but no gears in inventory");
			
		Transform container = gear.transform.parent;
		gear.transform.localPosition = Vector3.zero;
		gear.transform.localEulerAngles = Vector3.zero;
		container.transform.position = transform.position;
		container.transform.localEulerAngles = Vector3.up * 90.0f;
		gear.transform.Find("Axle In Gear").gameObject.SetActive(true);
		inventory.RemoveFromInventory(gear);
		
		container.gameObject.SetActive(true);
		
		inUse = true;
		gear.AttachToAxle(this);
		SetSelectable();
	}
	
	public void Free() {
		inUse = false;
		SetSelectable();
	}

	public override bool IsSelectable() {
		return (!inUse && inventory.FirstOfType("GearSelectable") != null);
	}
}
