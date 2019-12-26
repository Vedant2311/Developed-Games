using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardLauncher : MonoBehaviour {

    private Rigidbody2D rb;
    public float forceVal;

    
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * forceVal, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WallsLeft")
        {
            rb.AddForce(Vector3.right * forceVal, ForceMode2D.Impulse);

        }

        if (collision.tag == "WallsRight")
        {

            rb.AddForce(Vector3.left * forceVal, ForceMode2D.Impulse);

        }

      

    }


}
