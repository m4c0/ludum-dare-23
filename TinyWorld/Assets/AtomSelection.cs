using UnityEngine;
using System.Collections;

public class AtomSelection : MonoBehaviour {
	
	public Transform selection { get; protected set; }
	
	public Transform hover { get; protected set; }
	
	private bool _Picked() { return selection != null; }
	
	public void PostUpdate() {
		if (selection != null) {
			selection.rigidbody.velocity = Vector3.zero;
		}
	}
	
	public void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray, out hit)) {
			return;
		}

		Hover(hit.collider.transform);

		if (!Input.GetButtonDown("Fire1")) {
			return;
		}
		
		Select(hit.collider.transform);
	}
	
	private void Hover(Transform t) {
		if ((hover != null) && (hover != selection)) {
			(hover.GetComponent("Halo") as Behaviour).enabled = false;
		}
		hover = t;
		(hover.GetComponent("Halo") as Behaviour).enabled = true;
	}
	
	public void Select(Transform t) {
		if (selection != null) {
			(selection.GetComponent("Halo") as Behaviour).enabled = false;
		}
		selection = t;
		(selection.GetComponent("Halo") as Behaviour).enabled = true;
	}
}
