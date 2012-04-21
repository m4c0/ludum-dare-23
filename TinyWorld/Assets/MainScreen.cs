using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {

	public void OnGUI() {
		int left = Screen.width - 160 * 3 - 30;
		int bottom = Screen.height;
		if (GUI.Button(new Rect(left, bottom - 100, 150, 50), "Tutorial")) {
			Application.LoadLevel("IntroScene");
		}
		if (GUI.Button(new Rect(left + 160, bottom - 100, 150, 50), "Play")) {
			Application.LoadLevel("Methane");
		}
		if (GUI.Button(new Rect(left + 320, bottom - 100, 150, 50), "Sandbox")) {
			Application.LoadLevel("DunnoScene");
		}
	}
}
