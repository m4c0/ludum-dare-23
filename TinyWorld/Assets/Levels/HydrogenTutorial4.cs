using UnityEngine;
using System.Collections;

public class HydrogenTutorial4 : MonoBehaviour {
	
	public string nextLevel = "Oxygen";
	
	public GUISkin skin;
	
	private float fade = 1;
	private float time = 0;
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "Use your cursor keys (or WASD) to rotate your camera.");
		
		_Alphalulu(4);
		GUI.Label(new Rect(100, 150, 300, 50), "Your mouse wheel zooms in and out.");
		
		_Alphalulu(7);
		GUI.Label(new Rect(100, 200, 300, 50), "And you can click to select an atom.");
		
		_Alphalulu(10);
		GUI.Label(new Rect(100, 250, 300, 50), "Press SPACE when you are done.");
	}
	
	public void Update() {
		time += Time.deltaTime;
		
		fade = 1 - (time - 13);
		
		if (Input.GetButton("Jump")) {
			Application.LoadLevel(nextLevel);
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(time - min) * Mathf.Clamp01(fade);
		GUI.color = c;
	}
}
