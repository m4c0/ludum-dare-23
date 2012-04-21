using UnityEngine;
using System.Collections;

public class AddAtomScript : MonoBehaviour {
	
	public GameObject carbon;
	
	private Rect _carbonRect = new Rect(10, 10, 100, 25);
	
	public void OnGUI() {
		if (GUI.Button(_carbonRect, "Carbon")) {
			Instantiate(carbon);
		}
	}
	
}
