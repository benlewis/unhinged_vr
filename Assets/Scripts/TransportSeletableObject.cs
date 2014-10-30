using UnityEngine;
using System.Collections;

public class TransportSeletableObject : SelectableObject {
	
	public GameObject path;
	public GameObject walls;
	public string levelName;
	
	private Color baseColor;
	
	public override void Start() {
		base.Start ();
		baseColor = renderer.material.color;
		
	}

	public override void Select() {
		// disable the parent
		FollowPath platformPath = walls.GetComponentInParent<FollowPath>();
		
		platformPath.SetPath(path);
		platformPath.SetLevel(levelName);
		
		//walls.audio.Play();
		walls.SetActive(false);
		//Destroy (walls, walls.audio.clip.length);
	}
	
	public override void TurnOnHighlight() {
		base.TurnOnHighlight();
		
		renderer.material.color = Color.green;
	}
	
	public override void TurnOffHighlight() {
		base.TurnOffHighlight();
		
		renderer.material.color = baseColor;
	}
}
