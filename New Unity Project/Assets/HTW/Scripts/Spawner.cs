using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public GameObject Enemy;
    Vector3 offset = new Vector3(10, 0,0);
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SpawnTrigger");
        if (other.CompareTag("Player"))
        {
            Instantiate(Enemy, transform.position + offset, transform.rotation);
            Destroy(gameObject);
        }
    }
}