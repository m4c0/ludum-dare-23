using UnityEngine;
using System.Collections;

public class Thymine : AbstractLevel {

	public void Update() {
		if (won) return;
		if (transform.childCount != 15) return;
		
		foreach (Transform c in transform) {
			if (!c.GetComponent<AtomicLink>().IsFull) return;
		}
		foreach (Transform c in transform) {
			AtomicLink a = c.GetComponent<AtomicLink>();
			if (a.linkCount == 4) {
				_CheckCarbonCH3(a);
			}
		}
	}
	
	private void _CheckCarbonCH3(AtomicLink a) {
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
		if (c != null && (hcnt == 3)) _CheckCarbonNeighborCH3(a, c);
	}
	
	private void _CheckCarbonNeighborCH3(AtomicLink fu, AtomicLink a) {
		AtomicLink dble1 = null;
		AtomicLink dble2 = null;
		AtomicLink sgle = null;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (fu == link) continue;
			if (link.linkCount != 4) return;
			
			if (_CheckCarbonSingle(a, link)) {
				if (sgle != null) return;
				sgle = link;
			} else {
				if (dble1 == null) {
					dble1 = link;
				} else {
					if (dble1 != link) return;
					dble2 = link;
				}
			}
		}
		
		if ((sgle == null) || (dble2 == null)) return;
		
		StartCoroutine("_EndLevel");
	}
	
	private bool _CheckCarbonSingle(AtomicLink mrbase, AtomicLink a) {
		bool ook = false, nok = false;
		for (int i = 0; i < 4; i++) {
			var link = a.GetLink(i);
			if (mrbase == link) continue;
			
			switch (link.linkCount) {
			case 1: return false;
			case 2: if (!_CheckDoubleO(a, link)) return false; else ook = true; break;
			case 3: if (!_CheckNH1(mrbase, a, link)) return false; else nok = true; break;
			case 4: return false;
			}
		}
		return ook && nok;
	}
	
	private bool _CheckDoubleO(AtomicLink c, AtomicLink o) {
		return o.GetLink(0) == c && o.GetLink(1) == c;
	}
	
	private bool _CheckNH1(AtomicLink firstC, AtomicLink c, AtomicLink n) {
		bool cok = false, hok = false;
		for (int i = 0; i < 3; i++) {
			var link = n.GetLink(i);
			if (c == link) continue;
			
			switch (link.linkCount) {
			case 1: hok = true; break;
			case 2: return false;
			case 3: return false;
			case 4: cok = _CheckCarbonNeighborNH1(firstC, n, link); break;
			}
		}
		return cok && hok;
	}
	
	private bool _CheckCarbonNeighborNH1(AtomicLink firstC, AtomicLink n, AtomicLink c) {
		bool ook = false, nok = false;
		for (int i = 0; i < 4; i++) {
			var link = c.GetLink(i);
			if (n == link) continue;
			
			switch (link.linkCount) {
			case 1: return false;
			case 2: ook = _CheckDoubleO(c, link); break;
			case 3: nok = _CheckNH2(firstC, c, link); break;
			case 4: return false;
			}
		}
		return ook && nok;
	}
	
	private bool _CheckNH2(AtomicLink firstC, AtomicLink c, AtomicLink n) {
		bool cok = false, hok = false;
		for (int i = 0; i < 3; i++) {
			var link = n.GetLink(i);
			if (c == link) continue;
			
			switch (link.linkCount) {
			case 1: hok = true; break;
			case 2: return false;
			case 3: return false;
			case 4: cok = _CheckLastCarbon(firstC, n, link); break;
			}
		}
		return cok && hok;
	}
	
	private bool _CheckLastCarbon(AtomicLink firstC, AtomicLink n, AtomicLink c) {
		bool gotH = false;
		for (int i = 0; i < 3; i++) {
			var link = c.GetLink(i);
			if (n == link) continue;
			if (firstC == link) continue;
			
			if (link.linkCount != 1) return false;
			if (gotH) return false;
			gotH = true;
		}
		return true;
	}
	
}
