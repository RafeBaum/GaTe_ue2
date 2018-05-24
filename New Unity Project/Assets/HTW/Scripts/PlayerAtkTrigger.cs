using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkTrigger : MonoBehaviour {
    Collider2D foundCol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
        foundCol = collision;
        }
    }

    public Collider2D GetCol()
    {
        return foundCol;
    }
}
