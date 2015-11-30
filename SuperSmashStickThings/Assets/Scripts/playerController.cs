using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private Rigidbody2D m_rigidBody;
	private bool isGrounded;
	private float directionModifier;
	private Animator m_animator;

	// Use this for initialization
	void Start () {
	
		m_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		isGrounded = false;
		directionModifier = 1.0f;
		m_animator = gameObject.GetComponent<Animator> ();
		m_animator.SetBool ("isGrounded", true);
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "stage") {
			Debug.Log ("dfd");
			isGrounded = true;
			return;
		}
	}


	void FixedUpdate(){

		if (Input.GetKey (KeyCode.A)) {
			directionModifier = -1.0f;
			m_rigidBody.AddForce (new Vector2(Input.GetAxis ("Horizontal") * 20 , 0));



		} else if (Input.GetKey (KeyCode.D)) {
			directionModifier = 1.0f;
			m_rigidBody.AddForce (new Vector2(Input.GetAxis ("Horizontal") * 20, 0));
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			m_rigidBody.AddForce(new Vector2(0, 200));
			m_animator.SetTrigger("jumped");
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			//punch
		}

		transform.rotation = Quaternion.identity;
		m_animator.SetFloat("speed", Mathf.CeilToInt(m_rigidBody.velocity.x < 0 ? -1 * m_rigidBody.velocity.x : m_rigidBody.velocity.x));

	}


}
