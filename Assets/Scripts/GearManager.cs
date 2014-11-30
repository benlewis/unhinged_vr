using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* TODO
- Create a button & script to set Screen vs Oculus in all scenes
- Rotate the platform walls and show Level # options
- Use the medieval models to make the gear scene awesome
- Rotate the pegs
- Let the user pick up gears and place them, lifo

- Add long poles to connect gears 
- Download real textures/models to make the scene look more amazing
- Spruce up the scene with columns, wall fixtures, etc
- Figure out a better animation when gears enter/leave a peg
- Different materials to mark different gears: user placeable, starting power, fixed position, key gear
- Add sounds: gears moving, doors opening
- Figure out how lighting works. Make lighting awesome.

*/

/* DONE
- Use a real highlighting system with a temporary bright material for now ($35 to improve later on)
- Refactor the ClickableObject system instead of CreateGear
- Make the prize Clickable
- Make crouching box to not let you stand up when under something
- Add a door which moves when gears are hooked up to it
- Create the level selector with the map, elevator, and hallways/train ride
- Add music: awesome


*/

public class GearManager : MonoBehaviour {

	private static GearManager instance;
	private List<Gear> gears = new List<Gear>();
	private List<Gear> powerGears = new List<Gear>();
	
	[HideInInspector]
	public bool updateInProgress = false;

	public static GearManager Instance() {
		if (instance == null)
			instance = GameObject.Find ("GameManager").GetComponent<GearManager>();
		
		return instance;
	}

	public void AddGear(Gear g) {
		// Set the gear's peg to be not selectable
		//g.GetComponentInParent<SelectableObject>().SetSelectable();
	
		// Keep track of all gears in the scene
		if (!gears.Contains(g))
			gears.Add(g);
			
		if (g.startingPower != 0.0f && !powerGears.Contains(g)) {
			UpdateGears();
			powerGears.Add(g);
		}		
	}
	
	public void RemoveGear(Gear g) {
		// This gear's peg can now be selected to add a gear
		// TODO: Make this only possible in pegs that are allowed to have gears
		g.GetComponentInParent<SelectableObject>().SetSelectable();
		
		// Remove this from the list of gears in the scene
		if (gears.Contains(g))
			gears.Remove(g);
		
		// Remove this from our power gears as well, if applicable
		if (powerGears.Contains (g))
			powerGears.Remove(g);
		
		// Tell the other connected gears that we are not connected
		foreach (Gear otherGear in g.connectedGears) {
			otherGear.connectedGears.Remove(g);
		}
		
		// Empty our connected gears
		g.connectedGears.Clear();
		
		// Reset the scene
		UpdateGears();
	}
	
	// Go through all gears and set the right rotation
	private void UpdateGears() {
		updateInProgress = true;
		
		foreach (Gear g in gears) {
			g.rotationSpeed = g.startingPower;
		}
		
		foreach (Gear g in powerGears) {
			g.powerConnectedGears();	
		}
		
		updateInProgress = false;
	}
	
	public void ConnectGears(Gear a, Gear b) {
		bool newConnection = false;
		// Keep track of which gears are connected	
		if (!a.connectedGears.Contains (b)) {
			newConnection = true;
			a.connectedGears.Add (b);
		}
		
		if (!b.connectedGears.Contains (a)) {
			newConnection = true;
			b.connectedGears.Add (a);
		}
		
		if (newConnection) {		
			if (b.rotationSpeed == 0.0f)
				InterlockGears(b, a, new List<Gear>());
			else
				InterlockGears(a, b, new List<Gear>());
				
			UpdateGears();			
		}
	}
	
	private void InterlockGears(Gear a, Gear b, List<Gear> gearsToIgnore) {		
		// Make the gears offset so it looks like they are lined up properly
		Vector3 aAngle = a.transform.localEulerAngles;
		Vector3 bAngle = b.transform.localEulerAngles;
		
		float aY = aAngle.y % 36.0f;
		float rotationOffset = 13.5f - aY;
		
		b.transform.localEulerAngles = new Vector3(
			bAngle.x,
			rotationOffset,
			bAngle.z);
		
		if (!gearsToIgnore.Contains(a))
			gearsToIgnore.Add (a);	
			
		foreach (Gear g in b.connectedGears) {
			if (!gearsToIgnore.Contains(g))
				InterlockGears(b, g, gearsToIgnore);
		}
		
	}
	
	public void DisconnectGears(Gear a, Gear b) {
		bool newConnection = false;
		
		if (a.connectedGears.Contains (b)) {
			newConnection = true;
			a.connectedGears.Remove (b);
		}
		
		if (b.connectedGears.Contains (a)) {
			newConnection = true;
			b.connectedGears.Remove (a);
		}
		
		if (newConnection)		
			UpdateGears();
	}
	
}
