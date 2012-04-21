using UnityEngine;
using System.Collections;

public class AddAtomScript : MonoBehaviour {
	
	public AtomSelection selection;
	
	public GameObject carbon;
	public GameObject hydrogen;
	public GameObject oxygen;
	
	private Rect _hRect = new Rect(10, 10, 100, 25);
	private Rect _oRect = new Rect(10, 40, 100, 25);
	private Rect _cRect = new Rect(10, 70, 100, 25);
	
	public void OnGUI() {
		if (GUI.Button(_cRect, "Carbon")) {
			_Create(carbon);
		}
		if (GUI.Button(_hRect, "Hydrogen")) {
			_Create(hydrogen);
		}
		if (GUI.Button(_oRect, "Oxygen")) {
			_Create(oxygen);
		}
	}
	
	private void _Create(GameObject atom) {
		var s = selection.selection;
		if (s == null) {
			selection.selection = ((GameObject) Instantiate(atom)).transform;
			return;
		}
		
		Transform go = ((GameObject) Instantiate(atom)).transform;
		
		AtomicLink sal = s.GetComponent<AtomicLink>();
		AtomicLink goal = go.GetComponent<AtomicLink>();
		if ((sal.maxLinks > 0) && (goal.maxLinks > 0)) {
			sal.AddLink(go);
			goal.AddLink(s);
		}
		
		go.transform.parent = this.transform;
	}
	
}
