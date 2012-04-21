using UnityEngine;
using System.Collections;

public class AtomLoop : MonoBehaviour {

	public void Update () {
		foreach (ElectricCharge c in GetComponentsInChildren<ElectricCharge>()) {
			BroadcastMessage("ApplyForces", c);
		}
	}
}
