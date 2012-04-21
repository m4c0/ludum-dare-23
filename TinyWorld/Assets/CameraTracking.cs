using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

	public AtomSelection selector;
	public float speed = 2.0f;

	private GameObject lerpDontKnowAName;
	
	private Vector3 lerpSource;
	private Vector3 lerpTarget;
	private float lerpTime;
	
	public void Update() {
		var sel = selector.selection;
		if (sel == null) return;
		if (sel != lerpDontKnowAName) {
			lerpTime = 0;
			lerpTarget = sel.transform.position;
			lerpSource = transform.position;
			lerpDontKnowAName = sel;
		} else {
			lerpTime += Time.deltaTime * speed;
		}
		
		transform.position = Vector3.Lerp(lerpSource, lerpTarget, lerpTime); 
	}
	
}
