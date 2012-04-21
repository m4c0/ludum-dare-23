using UnityEngine;
using System.Collections;

public class RealIntroScript : MonoBehaviour {
	
	public float startTime = 12;
	public float rotationAngle = 720;
	
	private Material material;
	
	public void OnGUI() {
		_Alphalulu(0, true);
		GUI.Label(new Rect(100, 100, 200, 100), "We will talk about the wonderful (tiny) world of...");

		_Alphalulu(5, true);
		GUI.Label(new Rect(100, 100, 200, 100), "Yes!");

		_Alphalulu(9, false);
		GUI.Label(new Rect(100, 100, 200, 100), "Press Space to start");
	}
	
	public void Start() {
		material = GetComponent<MeshRenderer>().material;
		
		transform.localScale = Vector3.zero;
		transform.Rotate(new Vector3(0, 0, -rotationAngle));
	}
	
	public void Update() {
		float t = Time.timeSinceLevelLoad - startTime - 2;

		var ff = material.color;
		var tt = material.color;
		float ttt = 1;
		
		if (t > 10) {
			return;
		}

		if (t > 6) {
			t -= 6;
		}
		if ((t >= 0) && (t <= 1)) {
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
			transform.Rotate(new Vector3(0, 0, rotationAngle * Time.deltaTime));
			
			ff.a = 0;
			tt.a = 1;
			ttt = t;
		}
		if (t > 2) {
			ff.a = 1;
			tt.a = 0;
			ttt = Mathf.Clamp01(t - 2);
		}
		material.color = Vector4.Lerp(ff, tt, ttt);
	}
	
	private void _Alphalulu(float min, bool mustFade) {
		var c = GUI.color;
		float fade = 1;
		if (mustFade) fade -= Mathf.Clamp01(Time.timeSinceLevelLoad - startTime - min - 2);
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - startTime - min) * fade;
		GUI.color = c;
	}
}
