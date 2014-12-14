using UnityEngine;
using System.Collections;

public class GearSelectable : SelectableObject {

	private AxleSelectable attachedAxle = null;

	public override void Select() {	
		// Stop using normal physics and switch to magic gear physics
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezePosition;
		GetComponent<FreezeRelativeTorque>().enabled = true;
		
		// We can use this now
		inventory.AddToInventory(this);
				
		// Disable the gear mesh's parent
		transform.parent.gameObject.SetActive(false);
		
		if (attachedAxle) {
			attachedAxle.Free();
		}
		
//		Transform container = GetComponentInParent<Transform>();
//		Transform player = FindObjectsOfType<SelectObject>()[0].transform;
//		container.SetParent(player);
//		container.localPosition = Vector3.forward * 0.5f + Vector3.up * 0.2f;
//		container.localEulerAngles = Vector3.zero;
		  
	}
	
	public void AttachToAxle(AxleSelectable axle) {
		attachedAxle = axle;
	}
	
	public override bool IsSelectable() {
		//return !inventory.ItemInInventory(this);
		return true;
	}
}
