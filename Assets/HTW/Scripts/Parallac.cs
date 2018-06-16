using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallac : MonoBehaviour {
    public GameObject bg2;
    public GameObject bg3;
    public float scrollspeed2 = 0.01f;
    public float scrollspeed3 = 0.03f;
    public PlayerMovement player;


	
	// Update is called once per frame
	void Update () {
        transform.Translate(-player.move.x *0.005f, player.move.y, 0);
        bg2.transform.Translate(-player.move.x*scrollspeed2, player.move.y, 0);
        bg3.transform.Translate(-player.move.x*scrollspeed3, player.move.y, 0);

    }
}
