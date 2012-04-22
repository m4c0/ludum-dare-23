using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AtomicLink : MonoBehaviour {
	
	public int maxLinks;
	
	public int linkCount { get; protected set; }
	
	private Rigidbody[] links;
	
	private Transform me;
	
	public void AddLink(Component obj) {
		if (IsFull) return;
		if (links == null) {
			links = new Rigidbody[4];
		}
		links[linkCount++] = obj.GetComponent<Rigidbody>();
	}
	
	public AtomicLink GetLink(int i) {
		return links[i].GetComponent<AtomicLink>();
	}
	
	public bool IsFull { get { return maxLinks <= linkCount; } }
	
	public void Start() {
		me = GetComponent<Transform>();
	}

	public void Update() {
		for (int i = 0; i < linkCount; i++) {
			Rigidbody r = links[i];
			var force = me.position - r.position;
			r.AddForce(force * 10);
			
			for (int j = 0; j < linkCount; j++) {
				if (j == i) continue;
				
				Rigidbody r1 = links[j];
				force = r.position - r1.position;
				if (force.magnitude != 0) {
					force = 3 * force.normalized / (force.magnitude * force.magnitude);
				}
				r.AddForce(force);
			}
		}
	}
}
