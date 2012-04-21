using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {

	public void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 100, 30), "Tutorial")) {
			Application.LoadLevel("IntroScene");
		}
		if (GUI.Button(new Rect(10, 50, 100, 30), "Play")) {
			Application.LoadLevel("Methane");
		}
		if (GUI.Button(new Rect(10, 90, 100, 30), "Sandbox")) {
			Application.LoadLevel("DunnoScene");
		}
	}
}
