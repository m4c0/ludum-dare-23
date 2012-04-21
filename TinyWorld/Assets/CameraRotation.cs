using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	public void Update() {
		float x = Input.GetAxis("Vertical");
		float y = Input.GetAxis("Horizontal");
		var v = new Vector3(x, y, 0);
		transform.Rotate(v);
	}
}
