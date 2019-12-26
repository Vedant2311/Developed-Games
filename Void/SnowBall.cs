using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {

    public GameObject Player;
    float dist;
    float random;
    public float distance;
    Vector3 force;
    public float forceX;
    public float forceZ;

    private void Start()
    {
        GameObject gameObject = this.GetComponent<GameObject>();
        float posx;
        posx = gameObject.transform.position.x;
        //this needs to be changed
        if (posx < 0)
            force = new Vector3(forceX, 0,forceZ);
        else
            force = new Vector3(-1* forceX, 0, forceZ);
        random = Random.Range(0, 2.0f);
    }

    void Update()
    {
        dist = (Player.transform.position.y - transform.position.y);
        if (dist < 0)
            dist *= -1;
        if (dist < distance && random > 1)
        {
            gameObject.SetActive(true);
            random = 0;
            transform.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
