using UnityEngine;
using System.Collections;

public class AbstractLevel : MonoBehaviour {

	public string next;
	public string description;
	
	private bool won = false;
	
	public void OnGUI() {
		int y = Screen.height - 30;
		if (won) {
			GUI.Label(new Rect(400, y, 200, 30), "Kudos!");
		} else {
			GUI.Label(new Rect(400, y, 200, 30), "Objective: " + description);
		}
	}
	
	protected IEnumerator _EndLevel() {
		won = true;
		Destroy(GetComponent<AddAtomScript>());
		yield return new WaitForSeconds(3);
		Application.LoadLevel(next);
	}	
}
