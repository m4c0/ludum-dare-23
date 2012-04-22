using UnityEngine;
using System.Collections;

public class HydrogenTutorial1 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;
	
	public GUISkin skin;
	
	private HydrogenTutorial2 next;
	
	private float fade = 1;
	
	public void Start() {
		addAtom.enabled = false;
		
		next = GetComponent<HydrogenTutorial2>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 300, 60), "We start with the smallest, simplest, and yet most common element in our universe");
		
		_Alphalulu(4);
		GUI.Label(new Rect(100, 160, 300, 30), "Hydrogen");
	}
	
	public void Update() {
		addAtom.enabled = (selection.selection == null) && (Time.timeSinceLevelLoad > 7);
		
		fade = 1 - (Time.timeSinceLevelLoad - 6);
		
		if (!addAtom.enabled && (fade <= 0)) {
			next.enabled = true;
			Destroy(this);
		}
	}
	
	private void _Alphalulu(float min) {
		var c = GUI.color;
		c.a = Mathf.Clamp01(Time.timeSinceLevelLoad - min) * Mathf.Clamp01(fade);
		GUI.color = c;
	}
}
