using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour {

    public GameObject Player;
    public GameObject center;
    float dist;
    float random;
    public float distance;
    Vector3 force;
    public float forceX;
    public float forceZ;
    public float posx;

    private void Start()
    {
        posx = transform.position.x;
        random = Random.Range(0, 2.0f);
    }

    void Update()
    {
        dist = (Player.transform.position.y - transform.position.y);
        if (dist < 0)
            dist *= -1;
        if (dist < distance && random > 1)
        {
            if(posx>0)
            transform.position = new Vector3(center.transform.position.z - Player.transform.position.z, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(-1*(center.transform.position.z - Player.transform.position.z), transform.position.y, transform.position.z);
            
        }
    }
}
