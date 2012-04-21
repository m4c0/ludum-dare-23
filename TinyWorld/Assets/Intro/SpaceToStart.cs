using UnityEngine;
using System.Collections;

public class SpaceToStart : MonoBehaviour {
	
	public string nextScene = "DunnoScene";
	
	public void Update() {
		if (Input.GetButton("Jump")) {
			Application.LoadLevel(nextScene);
		}
	}
}
