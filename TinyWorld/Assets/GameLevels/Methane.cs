using UnityEngine;
using System.Collections;

public class Methane : AbstractLevel {
	
	public void Update() {
		if (transform.childCount != 5) return;
		
		foreach (Transform c in transform) {
			AtomicLink a = c.GetComponent<AtomicLink>();
			if ((a.linkCount == 4) && (a.IsFull)) {
				_CheckCarbon(a);
			}
		}
	}
	
	private void _CheckCarbon(AtomicLink a) {
		for (int i = 0; i < 4; i++) {
			if (a.GetLink(i).linkCount != 1) {
				return;
			}
		}
		
		StartCoroutine("_EndLevel");
	}
}
