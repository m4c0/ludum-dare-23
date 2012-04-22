using UnityEngine;
using System.Collections;

public class HydrogenTutorial2 : MonoBehaviour {

	public AddAtomScript addAtom;
	public AtomSelection selection;
	
	public GUISkin skin;
	
	private AtomicLink link;

	private HydrogenTutorial3 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		addAtom.enabled = false;
		link = selection.selection.GetComponent<AtomicLink>();
		next = GetComponent<HydrogenTutorial3>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "Since theme is not 'Alone Again', let's bind this guy with another hydrogen atom");
	}
	
	public void Update() {
		time += Time.deltaTime;
		
		addAtom.enabled = (!link.IsFull) && (time > 6);
		
		fade = 1 - (time - 5);
		
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
