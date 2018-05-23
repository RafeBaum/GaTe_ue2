using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    Rigidbody2D enemyRB;
    public float speed, jumpspeed;
    int maxHp = 100;
    int currHp;
    float hitRange, atkDelay, atkTimer;
	// Use this for initialization
	void Start () {
        enemyRB = GetComponent<Rigidbody2D>();
        currHp = maxHp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TakeDamage(int dmg)
    {
        Debug.Log("enemy takeDMG");
        currHp -= dmg;
        if(currHp<= 0)
        {
            Destroy(gameObject);
        }

    }
}
