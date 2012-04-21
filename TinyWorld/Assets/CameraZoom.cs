using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float maxZoom = 20;
	public float speed = 5;
	
	private float origin;
	
	public void Start() {
		origin = transform.localPosition.z;
	}
	
	public void Update() {
		float wheel = Input.GetAxis("Mouse ScrollWheel");
		
		var p = transform.localPosition;
		p.z += wheel * speed * Time.deltaTime;
		if (p.z < origin - maxZoom) p.z = origin - maxZoom;
		if (p.z > origin) p.z = origin;
		
		transform.localPosition = p;
	}
}
