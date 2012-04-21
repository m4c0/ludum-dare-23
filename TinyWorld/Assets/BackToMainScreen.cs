using UnityEngine;
using System.Collections;

public class BackToMainScreen : MonoBehaviour {

	public void OnGUI() {
		int left = Screen.width - 110;
		if (GUI.Button(new Rect(left, 10, 100, 30), "Main Menu")) {
			Application.LoadLevel("MainScreen");
		}
	}
}
