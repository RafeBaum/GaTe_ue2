using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
	Rigidbody2D rbPlayer;
	Vector2 move;
    public Collider2D atkTrigger;
    public PlayerAtkTrigger pat;
	public bool grounded = false;
	public float speed;
	public float jumpspeed;
    public int maxHP = 3;
    int currHP;
    float atkTimer;
    float atkCD = 2;
    bool lookDir;
   

    // Use this for initialization
    void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
        lookDir = true;
	}
	
	// Update is called once per frame
	void Update () {
		move = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
        if (move.x > 0 && !lookDir)
        {
            RotRight();
            
        }
        if (move.x < 0 && lookDir)
        {
            RotLeft();
        }
		
            if (atkTimer > 0)
                atkTimer -= Time.deltaTime;

            if (atkTimer < 0)
                atkTimer = 0;

        if (Input.GetMouseButtonDown(0))
        {
            if (atkTimer == 0)
            {
                    Attack();
                    atkTimer = atkCD;
                Debug.Log(atkTimer);
            }
        }
    }
	
    void RotRight()
    {
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
        lookDir = true;
    }
    void RotLeft()
    {
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
        lookDir = false;
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
     //TODO  
     //atktrigger richtig einbinden
       /* if (atkTrigger.IsTouching(pat.GetCol))
        {
            Destroy(pat.GetCol.gameObject);
        }*/
    }
}
