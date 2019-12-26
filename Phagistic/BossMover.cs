using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMover : MonoBehaviour
{


    private Rigidbody2D rb;

    public float minForceVal = 5f;
    public float maxforceVal = 10f;
    public float forceVal;
   

    public GameObject ExplosionPrefab;
    private ParticleSystem Explosion;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forceVal = Random.Range(minForceVal, maxforceVal);

        rb.AddForce(transform.up * forceVal, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Explosion = Instantiate(ExplosionPrefab).GetComponent<ParticleSystem>();
            Explosion.transform.position = transform.position;
            Explosion.gameObject.SetActive(true);

            Destroy(gameObject);  
            




        }

       if (collision.tag == "WallsLeft")
        {
            rb.AddForce(Vector3.right * forceVal, ForceMode2D.Impulse);

        }
           
       if (collision.tag == "WallsRight")
        {

            rb.AddForce(Vector3.left * forceVal, ForceMode2D.Impulse);

        }

        if (collision.tag == "Guard")
        {
            Destroy(gameObject);
        }

        

    }




}
