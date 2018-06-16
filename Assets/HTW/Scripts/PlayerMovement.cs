using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    
	Rigidbody2D rbPlayer;
	public Vector2 move;
    public Collider2D atkTrigger;
    public AtkTrigger pat;
	public bool grounded = false;
	public float speed;
	public float jumpspeed;
    public int maxHP = 3;
    public int currHP;
    float atkTimer, invul;
    float atkCD = 1;
    float invTime = 2;
    bool lookDir;
    Animator anim;
    public GameController gc;
    public Text text;
   

    // Use this for initialization
    void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
        lookDir = true;
        anim = GetComponent<Animator>();
        currHP = maxHP;
	}

    // Update is called once per frame
    void Update()
    {
        if (!gc.end)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (move.x > 0 && !lookDir)
            {
                Rotate();

            }
            if (move.x < 0 && lookDir)
            {
                Rotate();
            }

            if (invul > 0)
                invul -= Time.deltaTime;

            if (invul < 0)
                invul = 0;

            if (atkTimer > 0)
                atkTimer -= Time.deltaTime;

            if (atkTimer < 0)
                atkTimer = 0;

            if (Input.GetMouseButtonDown(0))
            {
                if (atkTimer == 0)
                {
                    MeleeAttack();
                    atkTimer = atkCD;
                }
            }

        }
    }
    
	
    void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
        lookDir = !lookDir;
    }
   

	void FixedUpdate(){
        rbPlayer.AddForce(move * speed*Time.deltaTime);
        anim.SetFloat("moveH", move.x);
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

    public void TakeDmg(int dmg)
    {
        if (invul == 0) { 
            Debug.Log("player DMG");
            currHP -= dmg;
            invul = invTime;
            if (currHP <= 0)
                Death();
        }
    }


    void MeleeAttack()
    {

        anim.Play("DragonAtk", -1, 0f);
        if (atkTrigger.IsTouching(pat.GetCol()))
        {
            Destroy(pat.GetCol().gameObject);
        }
        text.enabled = false;
    }

    void Death()
    {

    }
}
