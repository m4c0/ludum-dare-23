using UnityEngine;
using System.Collections;

public class AbstractLevel : MonoBehaviour {

	public GUISkin skin;
	
	public string next;
	public string description;
	
	protected bool won = false;
	
	public void OnGUI() {
		GUI.skin = skin;
		
		if (won) {
			GUIStyle style = skin.FindStyle("Kudos");
			int x = (Screen.width - 400) / 2;
			int y = (Screen.height - 40) / 2;
			GUI.Label(new Rect(x, y, 400, 40), "Kudos!", style);
		} else {
			GUIStyle style = skin.FindStyle("Objective");
			int x = (Screen.width - 400) / 2;
			int y = Screen.height - 40;
			GUI.Label(new Rect(x, y, 400, 30), "Objective: " + description, style);
		}
	}
	
	protected IEnumerator _EndLevel() {
		won = true;
		Destroy(GetComponent<AddAtomScript>());
		yield return new WaitForSeconds(3);
		Application.LoadLevel(next);
	}	
}
