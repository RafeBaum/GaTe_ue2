using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFixer : MonoBehaviour {
    public float offset = 62.4f;

    
    public void OnBecameInvisible()
    {
       
        gameObject.transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
    }


}
