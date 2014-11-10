using UnityEngine;
using System.Collections;

public class SkipTutorialSelectableObject : SelectableObject {
	
	public GameObject player;
	public Transform teleportLocation;

	public override void Select() {
		player.transform.position = teleportLocation.position;
		player.transform.rotation = teleportLocation.rotation;
	}
}
