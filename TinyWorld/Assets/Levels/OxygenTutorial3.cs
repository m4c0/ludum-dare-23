using UnityEngine;
using System.Collections;

public class OxygenTutorial3 : MonoBehaviour {
	
	public GUISkin skin;
	
	private float fade = 1;
	private float time = 0;
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "This is the famous H2O molecule (water, for friends).");

		_Alphalulu(4);
		GUI.Label(new Rect(100, 150, 300, 50), "If you are a regular human being, 60% of your body is made of this stuff.");

		_Alphalulu(9);
		GUI.Label(new Rect(100, 210, 300, 50), "Anything below that means you really need to seek medical attention.");
	}
	
	private float finish = 13;
	
	public void Update() {
		time += Time.deltaTime;
		
		fade = 1 - (time - finish);
		
		if ((fade <= 0)) {
			Application.LoadLevel("Carbon");
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(time - min) * Mathf.Clamp01(fade);
		GUI.color = c;
	}
}