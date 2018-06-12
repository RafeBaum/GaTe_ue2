using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    Rigidbody2D enemyRB;
    public float speed, jumpspeed;
    public AtkTrigger eat;
    public Collider2D enemyAtkTrigger;
    public float hitRange;
    float atkDelay, atkTimer;
    Animator anim;
    Transform playerTrans;
    Vector2 move;
    bool lookDir;
	
    // Use this for initialization
	void Start () {
        enemyRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lookDir = true;
    }
	
	// Update is called once per frame
	void Update () {
        move = playerTrans.position - transform.position;
        move = Vector3.Normalize(move);
        if (move.x > 0 && !lookDir)
        {
            Rotate();

        }
        if (move.x < 0 && lookDir)
        {
            Rotate();
        }

        if (atkTimer > 0)
            atkTimer -= Time.deltaTime;

        if (atkTimer < 0)
            atkTimer = 0;

        if (Vector2.Distance(transform.position,playerTrans.position) <= hitRange)
        {
            if (atkTimer == 0)
            {
                Attack();
                atkTimer = atkDelay;
            }
        }
        
	}

    void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
        lookDir = !lookDir;
    }

    private void FixedUpdate()
    {
        anim.SetFloat("moveH", move.x);
        if (Vector2.Distance(transform.position, playerTrans.position) >= hitRange)
        {
            enemyRB.AddForce(move*speed*Time.deltaTime);
            
        }
    }

  

    void Attack()
    {

        anim.Play("KnightAtk", -1, 0f);
       
        if (enemyAtkTrigger.IsTouching(eat.GetCol()))
        {
            eat.GetCol().gameObject.GetComponent<PlayerMovement>().TakeDmg(1);
            //Destroy(eat.GetCol().gameObject);

        }

    }
}
