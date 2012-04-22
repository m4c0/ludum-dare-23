using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	private static bool highlander = true;
	
	public void Start() {
		if (highlander) {
			audio.Play();
			highlander = false;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
