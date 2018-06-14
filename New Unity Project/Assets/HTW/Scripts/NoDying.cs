using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoDying : MonoBehaviour {
    public Text nopeText;
    float t;


    private void Update()
    {
        if (t > 0)
            t -= Time.deltaTime;
        if (t < 0)
            t = 0;
        if (t == 0)
            nopeText.enabled = false;
        else
            nopeText.enabled = true;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            nopeText.text = "U no die here!";
            t = 2;

        } 
    }

    
}
