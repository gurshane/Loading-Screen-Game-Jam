using UnityEngine;
using System.Collections;

public class iconController : MonoBehaviour {

	GameObject target;
	GameObject playerHealth;
	Rigidbody2D temp;
	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player");
		temp = GetComponent<Rigidbody2D> ();
		GetComponent<Animator> ().SetBool ("punching", true);
		playerHealth = GameObject.FindGameObjectWithTag ("PlayerHealth");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temps = Vector3.MoveTowards (transform.position, target.transform.position, 0);
		temp.AddForce (new Vector2(-temps.x, temps.y) * 3);
		transform.rotation = Quaternion.identity;
	}

}
