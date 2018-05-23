using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbPlayer;
	Vector2 move;
	public bool grounded = false;
	public float speed;
	public float jumpspeed;

	// Use this for initialization
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
		rbPlayer.AddForce (move * speed);
		if (grounded) {
			if (Input.GetKeyDown ("space")) {
				rbPlayer.AddForce (new Vector2 (0, 1) * jumpspeed);
				grounded = false;
				Debug.Log ("jump");
			}
		}
	}

	void FixedUpdate(){
	}

	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.CompareTag("Wall")){
			grounded = true;
		}
	}

}
