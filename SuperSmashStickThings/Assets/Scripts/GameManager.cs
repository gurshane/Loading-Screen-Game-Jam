using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Texture playerName;
	public Texture loadingName;

	public Canvas first;
	public Canvas second;

	GameObject text;
	GameObject playerHealth;
	GameObject loadingHealth;

	public GameObject TOTAL;

	bool toDisplay;

	// Use this for initialization
	void Start () {

		toDisplay = false;
		StartCoroutine ("loading");
	}

	IEnumerator loading() {

		yield return new WaitForSeconds (10);

		Application.LoadLevel ("level");

	}

	// Update is called once per frame
	void Update () {

		if (Input.anyKey) {
			toDisplay = true;
		}

	}

	void OnGUI(){
		GameObject temp;
		if (toDisplay) {
			StopAllCoroutines();
			temp = GameObject.FindGameObjectWithTag("loadingWall");
			DestroyImmediate (temp);
			first.gameObject.SetActive(false);
			second.gameObject.SetActive(true);
			toDisplay=false;
		}

	}


	public void setToDisplay(){

		toDisplay = true;

	}

}
