using UnityEngine;
using System.Collections;

public class CarbonTutorial3 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;

	private AtomicLink link;

	private CarbonTutorial4 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		addAtom.enabled = false;
		
		addAtom.oxygen = null;
		
		link = selection.selection.GetComponent<AtomicLink>();
		next = GetComponent<CarbonTutorial4>();
	}
	
	public void OnGUI() {
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "Some elements can make stronger binds, like these two.");

		_Alphalulu(3);
		GUI.Label(new Rect(100, 140, 300, 50), "Hover your mouse inside oxygen and click the button that will appear");

		_Alphalulu(6);
		GUI.Label(new Rect(100, 140, 300, 50), "Remember you can rotate your camera if needed");
	}
	
	private float finish = 10;
	
	public void Update() {
		time += Time.deltaTime;
		
		addAtom.enabled = (link.linkCount == 1) && (time > finish + 1);
		
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
