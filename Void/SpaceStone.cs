using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStone : MonoBehaviour {

    float time;
    bool collided = false;
    GameObject player;
    public GameObject clouds;

    private void Start()
    {
        clouds.SetActive(false);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 5000 && collided == true) {
            player.SetActive(true);
            clouds.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clouds.SetActive(true);
            player = other.gameObject; 
            other.gameObject.SetActive(false);
            time = 0;
            collided = true;
        }
    }
}
