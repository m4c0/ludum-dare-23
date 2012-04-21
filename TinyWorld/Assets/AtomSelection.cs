using UnityEngine;
using System.Collections;

public class AtomSelection : MonoBehaviour {
	
	public GameObject selection;
	
	private bool _Picked() { return selection != null; }

	public void Update () {
		if (!Input.GetButtonDown("Fire1")) {
			return;
		}
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray, out hit)) {
			selection = null;
			return;
		}
		
		if (selection == hit.collider.gameObject) {
			selection = null;
		} else {
			selection = hit.collider.gameObject;
		}
	}
}
