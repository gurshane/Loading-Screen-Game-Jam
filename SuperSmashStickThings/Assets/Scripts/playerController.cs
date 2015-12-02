using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	private Rigidbody2D m_rigidBody;
	private bool isGrounded;
	private float directionModifier;
	private Animator m_animator;

	bool isPunching;	
	GameObject loadingHealth;
	GameObject playerHealth;

	// Use this for initialization
	void Start () {
		
		isPunching = false;
		m_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		isGrounded = false;
		directionModifier = 1.0f;
		loadingHealth = GameObject.FindGameObjectWithTag ("LoadingHealth");
		playerHealth = GameObject.FindGameObjectWithTag ("PlayerHealth");

		m_animator = gameObject.GetComponent<Animator> ();
		m_animator.SetBool ("isGrounded", true);
	}
	
	// Update is called once per frame
	void Update () {

		loadingHealth = GameObject.FindGameObjectWithTag ("LoadingHealth");
		playerHealth = GameObject.FindGameObjectWithTag ("PlayerHealth");
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "stage") {
			isGrounded = true;
			return;
		}
		if (coll.gameObject.tag == "Icon") {
			string temp = loadingHealth.GetComponent<Text>().text;
			temp = temp.Substring(0, temp.Length -1);
			int tempDamage = int.Parse (temp);
			tempDamage += 10;
			if(tempDamage == 100){
				Application.LoadLevel ("level");
			}
			loadingHealth.GetComponent<Text>().text = tempDamage.ToString() + "%";
			playerHealth.GetComponent<Text>().text = tempDamage.ToString () + "%";
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

		if (Input.GetKeyDown (KeyCode.J) || Input.GetKey (KeyCode.J)) {
			isPunching = true;
			m_animator.SetBool ("punching", true);
		}

		if (Input.GetKeyUp (KeyCode.J)) {
			isPunching = false;
			m_animator.SetBool ("punching", false);
		}

		transform.rotation = Quaternion.identity;
		m_animator.SetFloat("speed", Mathf.CeilToInt(m_rigidBody.velocity.x < 0 ? -1 * m_rigidBody.velocity.x : m_rigidBody.velocity.x));

	}



}
