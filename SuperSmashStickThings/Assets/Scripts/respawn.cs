using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {
	public GameObject ICON;
	public GameObject PLAYER;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Icon") {
			Instantiate (ICON);
		} else {
			Instantiate (PLAYER);
		}
	}
}
