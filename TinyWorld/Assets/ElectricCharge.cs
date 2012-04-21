using UnityEngine;
using System.Collections;

public class ElectricCharge : MonoBehaviour {

	public static GameObject atoms;
	
	public bool positive;
	
	public void ApplyForces(ElectricCharge charge) {
		if (charge == this) return;
		var p = transform.position - charge.transform.position;
		p = p.normalized / (p.magnitude * p.magnitude);
		if (positive != charge.positive) p = -p;
		rigidbody.AddForce(p);
	}
}
