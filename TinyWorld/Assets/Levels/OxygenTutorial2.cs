using UnityEngine;
using System.Collections;

public class OxygenTutorial2 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;

	public GameObject hydrogen;
	
	private AtomicLink link;

	private OxygenTutorial3 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		addAtom.enabled = false;
		
		addAtom.oxygen = null;
		addAtom.hydrogen = hydrogen;
		
		link = selection.selection.GetComponent<AtomicLink>();
		next = GetComponent<OxygenTutorial3>();
	}
	
	public void OnGUI() {
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "We could add another oxygen atom like we did before but this tutorial would take forever to finish.");

		_Alphalulu(6);
		GUI.Label(new Rect(100, 150, 300, 50), "(BTW, that gives us the O2 molecule we breath everyday)");

		_Alphalulu(11);
		GUI.Label(new Rect(100, 200, 300, 50), "Instead, let's bind two Hydrogen instead.");
	}
	
	private float finish = 13;
	
	public void Update() {
		time += Time.deltaTime;
		
		addAtom.enabled = (!link.IsFull) && (link.maxLinks == 2) && (time > finish + 1);
		
		fade = 1 - (time - finish);
		
		if (!addAtom.enabled && (fade <= 0)) {
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
