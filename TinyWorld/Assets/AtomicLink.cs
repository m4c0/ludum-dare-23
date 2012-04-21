using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AtomicLink : MonoBehaviour {
	
	public int maxLinks;
	
	private Rigidbody[] links;
	
	private Transform me;
	
	public void AddLink(Component obj) {
		if (maxLinks <= 0) return;
		links[--maxLinks] = obj.GetComponent<Rigidbody>();
	}
	
	public void Start() {
		me = GetComponent<Transform>();
		links = new Rigidbody[maxLinks];
	}

	public void Update() {
		foreach (Rigidbody r in links) {
			if (r == null) continue;

			var force = me.position - r.position;
			r.AddForce(force);
		}
	}
}
