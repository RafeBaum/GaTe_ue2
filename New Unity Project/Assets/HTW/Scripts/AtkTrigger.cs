using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkTrigger : MonoBehaviour {
    Collider2D foundCol;
    public string target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(target))
        {
        foundCol = collision;
        }
    }

    public Collider2D GetCol()
    {
        return foundCol;
    }
}
