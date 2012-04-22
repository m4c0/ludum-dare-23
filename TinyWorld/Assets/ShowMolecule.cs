using UnityEngine;
using System.Collections;

public class ShowMolecule : MonoBehaviour {

	public Transform atoms;
	
	public int imageWidth;
	public int imageHeight;

	private GUITexture texture;
	
	private Rect source;
	private Rect target;
	
	public void Start() {
		atoms.gameObject.active = false;
		texture = GetComponent<GUITexture>();
		
		float tw = imageWidth;
		float th = imageHeight;
		
		float sw = Screen.width - tw;
		float sh = Screen.height - th;
		
		texture.pixelInset = source = new Rect(sw / 2, sh / 2, tw, th);
		
		target = new Rect(10, 10, tw/4, th/4);
	}
	
	public void Update() {
		if (Time.timeSinceLevelLoad < 1) {
			return;
		}
		if (Time.timeSinceLevelLoad > 2.1) {
			atoms.gameObject.active = true;
		}

		float time = Mathf.Clamp01(Time.timeSinceLevelLoad - 1);
		texture.pixelInset = new Rect(
			Mathf.Lerp(source.x, target.x, time),
			Mathf.Lerp(source.y, target.y, time),
			Mathf.Lerp(source.width, target.width, time),
			Mathf.Lerp(source.height, target.height, time)
			);
	}
	
}
