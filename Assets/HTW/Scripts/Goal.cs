using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public GameController gc;
    public GameObject player;



    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gc.Win();
        }
    }

    private void Update()
    {
        if (gc.win)
        {
            transform.position = player.transform.position;
        }
    }
}
