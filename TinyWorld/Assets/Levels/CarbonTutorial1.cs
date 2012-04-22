using UnityEngine;
using System.Collections;

public class CarbonTutorial1 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;
	
	public GUISkin skin;
	
	private CarbonTutorial2 next;
	
	private float fade = 1;
	
	public void Start() {
		addAtom.enabled = false;
		
		next = GetComponent<CarbonTutorial2>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(0);
		GUI.Label(new Rect(100, 100, 300, 50), "Last part of this tutorial (finally, huh?)");
		
		_Alphalulu(3);
		GUI.Label(new Rect(100, 150, 300, 30), "Carbon");
	}
	
	private float finish = 5;
	
	public void Update() {
		addAtom.enabled = (selection.selection == null) && (Time.timeSinceLevelLoad > finish + 1);
		
		fade = 1 - (Time.timeSinceLevelLoad - finish);
		
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
