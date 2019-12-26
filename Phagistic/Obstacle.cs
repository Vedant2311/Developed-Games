using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
   
   
    private Rigidbody2D rb;
   
    public float minForceVal = 10f;
    public float maxforceVal = 20f;
    public GameObject InjuredPrefab;
    private ParticleSystem Injury;
    public GameObject ExplosionPrefab;
    private ParticleSystem Explosion;


   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float forceVal = Random.Range(minForceVal, maxforceVal);
        
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

        if (collision.tag == "DeadZone")
        {

            Injury = Instantiate(InjuredPrefab).GetComponent<ParticleSystem>();
            Injury.transform.position = transform.position;
            Injury.gameObject.SetActive(true);
            Injury.Play();
            Destroy(gameObject);
          
            
        }

    } 

   


}
