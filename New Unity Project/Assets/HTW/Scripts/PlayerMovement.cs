using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
	Rigidbody2D rbPlayer;
	Vector2 move;
    public Collider2D atkTrigger;
	public bool grounded = false;
	public float speed;
	public float jumpspeed;
    public int maxHP = 3;
    int currHP;
    public float atkRate, atkCD;
    bool lookDir;

    // Use this for initialization
    void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
        if (move.x > 0)
        {
            lookDir = true;
        }
        else
            lookDir = false;
     //TODO 
     //umdrehen richten 
     //atktrigger richtig einbinden
		
            if (atkRate > 0)
                atkRate -= Time.deltaTime;

            if (atkRate < 0)
                atkRate = 0;

        if (Input.GetMouseButtonDown(0))
        {
            if (atkRate == 0)
            {
                    Attack();
                    atkRate = atkCD;
                Debug.Log(atkRate);
            }
        }
    }
	

	void FixedUpdate(){
        rbPlayer.AddForce(move * speed*Time.deltaTime);
        if (grounded)
        {
            if (Input.GetKeyDown("space"))
            {
                rbPlayer.AddForce(new Vector2(0, 1) * jumpspeed);
                grounded = false;
               
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Wall")){
			grounded = true;
		}
	}


    void Attack()
    {
       
    }
}
