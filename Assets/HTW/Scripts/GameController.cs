using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Text  ripTxt;
    public PlayerMovement playerScript;
    public GameObject life1, life2, life3;
    public bool end, win;

	// Use this for initialization
	void Start () {
        ripTxt.enabled = false;
        end = false;
        win = false;
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
        if (end && !win)
        {
            End();
        }
        if (win)
            Win();
    }

   public  void End()
    {
        
            ripTxt.text = "he's dead Jim...";
       
        ripTxt.enabled =true;
        end = true;
       StartCoroutine( DelayedReload());

    }

    public void Win()
    {
        ripTxt.text = "And so he Takes the princces home to... do.. stuff..";
       
        ripTxt.enabled = true;
        win = true;
        end = true;
        StartCoroutine(DelayedQuit());
       

    }

    IEnumerator DelayedReload()
    {

        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelayedQuit()
    {

        yield return new WaitForSecondsRealtime(5);
        Application.Quit();
    }
}
