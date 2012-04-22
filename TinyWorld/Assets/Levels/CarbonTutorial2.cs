using UnityEngine;
using System.Collections;

public class CarbonTutorial2 : MonoBehaviour {
	
	public AddAtomScript addAtom;
	public AtomSelection selection;

	public GUISkin skin;
	
	public GameObject oxygen;
	
	private AtomicLink link;

	private CarbonTutorial3 next;
	
	private float fade = 1;
	private float time = 0;
	
	public void Start() {
		addAtom.enabled = false;
		
		addAtom.carbon = null;
		addAtom.oxygen = oxygen;
		
		link = selection.selection.GetComponent<AtomicLink>();
		next = GetComponent<CarbonTutorial3>();
	}
	
	public void OnGUI() {
		GUI.skin = skin;
		
		_Alphalulu(1);
		GUI.Label(new Rect(100, 100, 300, 50), "Carbon is a funny element.");

		_Alphalulu(3);
		GUI.Label(new Rect(100, 130, 300, 50), "It can be fragile as graphite or strong as diamond.");

		_Alphalulu(6);
		GUI.Label(new Rect(100, 180, 300, 50), "Oh, and life on Earth is made of it.");
	}
	
	private float finish = 9;
	
	public void Update() {
		time += Time.deltaTime;
		
		addAtom.enabled = (link.linkCount == 0) && (time > finish + 1);
		
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
