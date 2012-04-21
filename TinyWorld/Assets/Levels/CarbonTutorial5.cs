using UnityEngine;
using System.Collections;

public class CarbonTutorial5 : MonoBehaviour {
	
	private float fade = 1;
	private float time = 0;
	
	public void OnGUI() {
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "'CO' steals oxygen. Imagine your lungs full of it. This means no oxygen to live.");

		_Alphalulu(5);
		GUI.Label(new Rect(100, 150, 300, 50), "Now, imagine our atmosphere full of it. Yes, no more kittens.");

		_Alphalulu(9);
		GUI.Label(new Rect(100, 200, 300, 50), "The good news is: this tutorial is over! Let's play!");
	}
	
	private float finish = 12;
	
	public void Update() {
		time += Time.deltaTime;
		
		fade = 1 - (time - finish);
		
		if ((fade <= 0)) {
			Application.LoadLevel("Methane");
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(time - min) * Mathf.Clamp01(fade);
		GUI.color = c;
	}
}
