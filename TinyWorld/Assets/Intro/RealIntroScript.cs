using UnityEngine;
using System.Collections;

public class RealIntroScript : MonoBehaviour {
	
	public float startTime = 12;
	public float rotationAngle = 720;
	
	public GUISkin skin;
	
	private Material material;
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(0, 3);
		GUI.Label(new Rect(100, 100, 380, 100), "We will talk about the wonderful (tiny) world of...");

		_Alphalulu(5, 1);
		GUI.Label(new Rect(100, 100, 200, 100), "Yes!");
	}
	
	public void Start() {
		material = GetComponent<MeshRenderer>().material;
		
		transform.localScale = Vector3.zero;
		transform.Rotate(new Vector3(0, 0, -rotationAngle));
	}
	
	public void Update() {
		float t = Time.timeSinceLevelLoad - startTime - 3;

		var ff = material.color;
		var tt = material.color;
		float ttt = 1;
		
		if (t > 8) {
			Application.LoadLevel("Hydrogen");
			return;
		}

		if (t > 4) {
			t -= 4;
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
	
	private void _Alphalulu(float min, float max) {
		var c = GUI.color;
		float fade = 1;
		if (max > 0) fade -= Mathf.Clamp01(Time.timeSinceLevelLoad - startTime - min - max);
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - startTime - min) * fade;
		GUI.color = c;
	}
}
