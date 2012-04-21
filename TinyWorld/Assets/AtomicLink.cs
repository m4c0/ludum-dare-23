using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AtomicLink : MonoBehaviour {
	
	public Rigidbody link;
	
	private Transform me;
	
	public void Start() {
		me = GetComponent<Transform>();
	}

	public void Update() {
		var force = me.position - link.position;
		link.AddForce(force);
	}
}
