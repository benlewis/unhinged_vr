﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		// Keep track of all gears in the scene
		if (!gears.Contains(g))
			gears.Add(g);
			
		if (g.startingPower != 0.0f && !powerGears.Contains(g)) {
			Debug.Log ("power gear");
			UpdateGears();
			powerGears.Add(g);
		}
		
		Debug.Log("Added gear with starting power " + g.startingPower);		
	}
	
	public void RemoveGear(Gear g) {
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
			Debug.Log("Setting power from starting to " + g.startingPower);
			g.rotationSpeed = g.startingPower;
		}
		
		foreach (Gear g in powerGears) {
			Debug.Log ("Calling power connected Gears");
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
