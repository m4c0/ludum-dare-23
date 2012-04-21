using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
	
	public float tempo = 3;
	
	private float fade = 1;
	
	public void OnGUI() {
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 200, 30), "Once upon a time...");
		
		_Alphalulu(2);
		GUI.Label(new Rect(100, 130, 200, 30), "in a galaxy far, far away...");
		
		_Alphalulu(4);
		GUI.Label(new Rect(100, 160, 200, 30), "erm...");
		
		_Alphalulu(5);
		GUI.Label(new Rect(100, 190, 300, 30), "nope, you will not see a George Lucas's");
		GUI.Label(new Rect(100, 210, 300, 30), "rip-off in huge space battles...");
		
		_Alphalulu(8);
		GUI.Label(new Rect(100, 240, 300, 30), "after all, the theme is TINY worlds...");
		
		float time = Time.timeSinceLevelLoad;
		if (time > 11) fade -= tempo * Time.deltaTime;
		if (fade < 0) fade = 0;
		if (time > 12) {
			gameObject.AddComponent<RealIntroScript>();
			Destroy(this);
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - min) * fade;
		GUI.color = c;
	}
}
