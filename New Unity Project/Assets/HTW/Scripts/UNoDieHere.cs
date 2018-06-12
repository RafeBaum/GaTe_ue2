using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UNoDieHere : MonoBehaviour {
	public Text displaytext;
	float t;

	void Update(){
		if (t > 0) {
			t -= Time.deltaTime;
		}
		if (t < 0) {
			t = 0;
		}
		if (t == 0) {
			displaytext.enabled = false;
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("coll call");
			DisplayText ();
		}

	}


	void DisplayText(){
		Debug.Log ("display call");
		displaytext.text = "U no die here!";
		t = 2;
		displaytext.enabled = true;

	}

}
