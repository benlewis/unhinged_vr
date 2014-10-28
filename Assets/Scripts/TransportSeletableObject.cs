using UnityEngine;
using System.Collections;

public class TransportSeletableObject : SelectableObject {
	
	public Transform pathToFollow;
	public string levelName;
	
	private Color baseColor;
	
	public void Start() {
		baseColor = renderer.material.color;
	}

	public override void Select() {

	}
	
	public override void TurnOnHighlight() {
		base.TurnOnHighlight();
		
		Debug.Log ("turn on highlight");
		renderer.material.color = Color.green;
	}
	
	public override void TurnOffHighlight() {
		base.TurnOffHighlight();
		
		renderer.material.color = baseColor;
	}
}
