using UnityEngine;
using System.Collections;

public class CarbonicAcid : AbstractLevel {

	public void Update() {
		if (won) return;
		if (transform.childCount != 6) return;
		
		foreach (Transform c in transform) {
			AtomicLink a = c.GetComponent<AtomicLink>();
			if ((a.linkCount == 4) && (a.IsFull)) {
				_CheckCarbonA(a);
			}
		}
	}
	
	private void _CheckCarbonA(AtomicLink a) {
		int ocnt = 0;
		int o2cnt = 0;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (link.linkCount == 2) {
				if (_CheckOxygenA(link)) ocnt++;
				if (_CheckOxygenB(link)) o2cnt++;
			} else {
				return;
			}
		}
		if (ocnt == 2 && o2cnt == 2) StartCoroutine("_EndLevel");
	}
	
	private bool _CheckOxygenA(AtomicLink o) {
		if (o.GetLink(0).linkCount == 1) return true;
		if (o.GetLink(1).linkCount == 1) return true;
		return false;
	}
	
	private bool _CheckOxygenB(AtomicLink o) {
		return ((o.GetLink(0).linkCount == 4) && (o.GetLink(1).linkCount == 4));
	}
}
