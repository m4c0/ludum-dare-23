using UnityEngine;
using System.Collections;

public class RealIntroScript : MonoBehaviour {

	public void OnGUI() {
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 200, 100), "We will talk about the wonderful (tiny) world of...");
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - 12 - min);
		GUI.color = c;
	}
}
