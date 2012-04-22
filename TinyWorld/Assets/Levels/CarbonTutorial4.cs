using UnityEngine;
using System.Collections;

public class CarbonTutorial4 : MonoBehaviour {
		
	public AddAtomScript addAtom;
	public AtomSelection selection;

	public GUISkin skin;
	
	public GameObject oxygen;
	
	private AtomicLink link;

	private CarbonTutorial5 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		addAtom.enabled = false;
		
		addAtom.oxygen = oxygen;
		
		link = selection.selection.GetComponent<AtomicLink>();
		next = GetComponent<CarbonTutorial5>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 60), "This is Carbon Monoxide. Something your car spits in atmosphere");

		_Alphalulu(4);
		GUI.Label(new Rect(100, 160, 300, 50), "Want to know why it's a dangerous molecule?");

		_Alphalulu(7);
		GUI.Label(new Rect(100, 200, 300, 50), "Add another atom and another extra bond!");
	}
	
	private float finish = 13;
	
	public void Update() {
		time += Time.deltaTime;
		
		if (link.linkCount == 3) {
			addAtom.oxygen = null;
		}
		addAtom.enabled = (!link.IsFull) && (time > finish + 1);
		
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
