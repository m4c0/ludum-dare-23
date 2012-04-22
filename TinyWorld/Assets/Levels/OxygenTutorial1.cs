using UnityEngine;
using System.Collections;

public class OxygenTutorial1 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;
	
	public GUISkin skin;
	
	private OxygenTutorial2 next;
	
	private float fade = 1;
	
	public void Start() {
		addAtom.enabled = false;
		next = GetComponent<OxygenTutorial2>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 300, 50), "Let's play with another atom now");
		
		_Alphalulu(2);
		GUI.Label(new Rect(100, 140, 300, 30), "Oxygen");
	}
	
	public void Update() {
		addAtom.enabled = (selection.selection == null) && (Time.timeSinceLevelLoad > 5);
		
		fade = 1 - (Time.timeSinceLevelLoad - 4);
		
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
