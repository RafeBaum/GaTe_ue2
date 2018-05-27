using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text  ripTxt;
    public PlayerMovement playerScript;
    public GameObject life1, life2, life3;
    bool end;

	// Use this for initialization
	void Start () {
        ripTxt.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
	}

    void UpdateUI()
    {
       if(playerScript.currHP < 1)
        {
            life1.SetActive(false);
            end = true;
        }
       if (playerScript.currHP < 2)
       {
            life2.SetActive(false);
        }
       if (playerScript.currHP < 3)
       {
            life3.SetActive(false);
        }
        if (end)
        {
            End();
        }
    }

    void End()
    {
        Time.timeScale = 0;
        ripTxt.gameObject.SetActive(true);

    }
}
