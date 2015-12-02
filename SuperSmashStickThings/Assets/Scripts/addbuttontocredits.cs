using UnityEngine;
using System.Collections;

public class addbuttontocredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		
		if (GUI.Button (new Rect (Screen.width / 2, 220, 150, 70), "BackToMenu")) {
			Application.LoadLevel ("menu screen");
		}
	}

}
