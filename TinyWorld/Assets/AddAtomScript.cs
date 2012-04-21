using UnityEngine;
using System.Collections;

public class AddAtomScript : MonoBehaviour {
	
	public AtomSelection selection;
	
	public bool mayReset = true;
	
	public GameObject carbon;
	public GameObject hydrogen;
	public GameObject oxygen;
	
	private Rect _hRect = new Rect(10, 10, 100, 25);
	private Rect _oRect = new Rect(10, 40, 100, 25);
	private Rect _cRect = new Rect(10, 70, 100, 25);
	
	private Rect _extraRect = new Rect(10, 150, 100, 25);
	private Rect _resetRect = new Rect(10, 200, 100, 25);
	
	public void OnGUI() {
		_AddAddButtons();
		
		if (mayReset && GUI.Button(_resetRect, "Reset")) {
			foreach (Transform t in transform) {
				Destroy(t.gameObject);
			}
		}

		// It's three o'clock - all night and no sleep makes jack a dull boy
		_CoolTimeToBondJamesBond();
	}
	
	private void _AddAddButtons() {
		var s = selection.selection;
		if (s != null) {
			var sal = s.GetComponent<AtomicLink>();
			if (sal.IsFull) return;
		}

		if ((carbon != null) && GUI.Button(_cRect, "Carbon")) {
			_Create(carbon);
		}
		if ((hydrogen != null) && GUI.Button(_hRect, "Hydrogen")) {
			_Create(hydrogen);
		}
		if ((oxygen != null) && GUI.Button(_oRect, "Oxygen")) {
			_Create(oxygen);
		}
	}
	
	private void _CoolTimeToBondJamesBond() {
		var s = selection.selection;
		if (s == null) return;
		var sal = s.GetComponent<AtomicLink>();
		if (sal.IsFull) return;
		
		var h = selection.hover;
		if ((h == null) || (s == h)) return;
		var hal = h.GetComponent<AtomicLink>();
		if (hal.IsFull) return;
		
		if (GUI.Button(_extraRect, "Extra Bond")) {
			sal.AddLink(h);
			hal.AddLink(s);
		}
	}

	private void _Create(GameObject atom) {
		var s = selection.selection;
		if (s == null) {
			selection.Select(_Instantiate(atom));
			return;
		}
		
		AtomicLink sal = s.GetComponent<AtomicLink>();
		if (sal.IsFull) return;
		
		Transform go = _Instantiate(atom);
		
		AtomicLink goal = go.GetComponent<AtomicLink>();
		sal.AddLink(go);
		goal.AddLink(s);
	}

	private Transform _Instantiate(GameObject atom) {
		Transform res = ((GameObject) Instantiate(atom)).transform;
		res.parent = transform;
		res.position = transform.position + Random.onUnitSphere * 2;
		return res;
	}
}
