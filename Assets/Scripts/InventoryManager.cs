using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

	public List<MonoBehaviour> inventory = new List<MonoBehaviour>();

	public bool AddToInventory(MonoBehaviour item) {
		if (ItemInInventory(item))
			return false;
			
		inventory.Add(item);
		Debug.Log ("Adding a " + item.GetType().ToString() + " to inventory");
		UpdateSelectables();
		
		return true;
	}
	
	private void UpdateSelectables() {
		foreach (SelectableObject o in FindObjectsOfType<SelectableObject>()) {
			Debug.Log ("Checking selectable for " + o.name);
			o.SetSelectable();
		}
	}
	
	public bool ItemInInventory(MonoBehaviour item) {
		return inventory.Contains(item);
	}
	
	public void RemoveFromInventory(MonoBehaviour item) {
		inventory.Remove(item);
		UpdateSelectables();
	}
	
	public MonoBehaviour FirstOfType(string type) {
		Debug.Log("Searching inventory for a " + type);
		MonoBehaviour i = inventory.Find(item => item.GetType().ToString() == type);		
		if (i) 
			Debug.Log ("Found a " + i.GetType().ToString()+  " in inventory");
		
		return i;
	}
}
