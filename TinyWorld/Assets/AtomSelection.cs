using UnityEngine;
using System.Collections;

public class AtomSelection : MonoBehaviour {
	
	public Transform selection { get; protected set; }
	
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

		Select(hit.collider.transform);
	}
	
	public void Select(Transform t) {
		if (selection != null) {
			(selection.GetComponent("Halo") as Behaviour).enabled = false;
		}
		selection = t;
		(selection.GetComponent("Halo") as Behaviour).enabled = true;
	}
}
