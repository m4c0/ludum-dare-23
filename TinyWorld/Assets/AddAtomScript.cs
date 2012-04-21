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
	
	private Rect _resetRect = new Rect(10, 200, 100, 25);
	
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
		if (GUI.Button(_resetRect, "Reset")) {
			foreach (Transform t in transform) {
				Destroy(t.gameObject);
			}
		}
	}

	private Transform go;
	private void _Create(GameObject atom) {
		var s = selection.selection;
		if (s == null) {
			selection.selection = _Instantiate(atom);
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
