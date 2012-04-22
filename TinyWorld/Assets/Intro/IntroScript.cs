using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	
	public float tempo = 3;
	
	public GUISkin skin;
	
	private float fade = 1;
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 400, 30), "Once upon a time...");
		
		_Alphalulu(2);
		GUI.Label(new Rect(100, 130, 400, 30), "...in a galaxy far, far away...");
		
		_Alphalulu(4);
		GUI.Label(new Rect(100, 160, 400, 30), "erm...");
		
		_Alphalulu(5);
		GUI.Label(new Rect(100, 190, 400, 40), "Nope, you will not see a George Lucas's rip-off in huge space battles.");
		
		_Alphalulu(8);
		GUI.Label(new Rect(100, 240, 400, 30), "After all, the theme is TINY worlds!");
		
		float time = Time.timeSinceLevelLoad;
		if (time > 11) fade -= tempo * Time.deltaTime;
		if (fade < 0) fade = 0;
		if (time > 12) {
			Destroy(this);
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - min) * fade;
		GUI.color = c;
	}
}
