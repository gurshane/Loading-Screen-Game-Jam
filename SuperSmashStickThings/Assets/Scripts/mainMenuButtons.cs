using UnityEngine;
using System.Collections;

public class mainMenuButtons : MonoBehaviour {

	private Color GUIColor;

	// Use this for initialization
	void Start () {

		GUIColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUIColor.a = 0.3f;
		GUI.color = GUIColor;

		if (GUI.Button (new Rect (Screen.width/2, 220, 150, 70), "PLAY")) {
			Application.LoadLevel("loadingScreen");
		}

		if (GUI.Button (new Rect (Screen.width/2, 370, 150, 70), "CREDITS")) {
			Application.LoadLevel("credits");
		}

		if (GUI.Button (new Rect (Screen.width/2, 500, 150, 70), "STUFF")) {
			Application.LoadLevel("loadingScreen");
		}
	}

}
