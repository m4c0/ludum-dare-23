using UnityEngine;
using System.Collections;

public class Methylpropane : AbstractLevel {
	
	public void Update() {
		if (won) return;
		if (transform.childCount != 14) return;
		
		foreach (Transform c in transform) {
			AtomicLink a = c.GetComponent<AtomicLink>();
			if ((a.linkCount == 4) && (a.IsFull)) {
				_CheckCarbonA(a);
			}
		}
	}
	
	private void _CheckCarbonA(AtomicLink a) {
		AtomicLink c = null;
		int hcnt = 0;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (link.linkCount == 1) {
				hcnt++;
			} else if (link.linkCount == 4) {
				c = link;
			}
		}
		if (c != null && (hcnt == 3)) _CheckCarbonB(a, c);
	}
	
	private void _CheckCarbonB(AtomicLink xii, AtomicLink a) {
		int hcnt = 0;
		int ccnt = 0;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (link == xii) continue;
			if (link.linkCount == 1) {
				hcnt++;
			} else if (link.linkCount == 4) {
				if (!_CheckCarbonC(link)) return;
				ccnt++;
			} else {
				return;
			}
		}
		if (hcnt == 1 && ccnt == 2) StartCoroutine("_EndLevel");
	}
	
	private bool _CheckCarbonC(AtomicLink a) {
		int hcnt = 0;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (link.linkCount == 1) {
				hcnt++;
			}
		}

		return (hcnt == 3);
	}
}
