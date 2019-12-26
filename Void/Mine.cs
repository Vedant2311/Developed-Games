using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    public ParticleSystem explosion;
    public GameObject mine;

    private void Start()
    {
        explosion.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //dec player health
            mine.SetActive(false);
            explosion.gameObject.SetActive(true);
            explosion.Play();
        }
    }
}
