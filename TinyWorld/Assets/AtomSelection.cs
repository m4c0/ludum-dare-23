using UnityEngine;
using System.Collections;

public class AtomSelection : MonoBehaviour {
	
	public GameObject selection;
	
	private bool _Picked() { return selection != null; }
	
	public void PostUpdate() {
		if (selection != null) {
			selection.rigidbody.velocity = Vector3.zero;
		}
	}
	
	public void Update () {
		if (!Input.GetButtonDown("Fire1")) {
			return;
		}
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray, out hit)) {
			return;
		}
		
		selection = hit.collider.gameObject;
	}
}
