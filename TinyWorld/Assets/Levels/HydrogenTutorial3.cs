using UnityEngine;
using System.Collections;

public class HydrogenTutorial3 : MonoBehaviour {
	
	private HydrogenTutorial4 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		next = GetComponent<HydrogenTutorial4>();
	}
	
	public void OnGUI() {
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "Now, we have a hydrogen molecule (a.k.a. 'H2')!");
		
		_Alphalulu(4);
		GUI.Label(new Rect(100, 130, 300, 50), "Yeah, boring, I know. We will get into cooler molecules later.");
		
		_Alphalulu(7);
		GUI.Label(new Rect(100, 190, 300, 50), "But let's take some time to explain camera controls.");
	}
	
	public void Update() {
		time += Time.deltaTime;
		
		fade = 1 - (time - 10);
		
		if ((fade <= 0)) {
			next.enabled = true;
			Destroy(this);
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(time - min) * Mathf.Clamp01(fade);
		GUI.color = c;
	}
}
