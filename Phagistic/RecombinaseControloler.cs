using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecombinaseControloler : MonoBehaviour {

    private Rigidbody2D rb;

    public float minForceVal = 10f;
    public float maxforceVal = 20f;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        float forceVal = Random.Range(minForceVal, maxforceVal);

        rb.AddForce(transform.up * forceVal, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }
	
	
}
