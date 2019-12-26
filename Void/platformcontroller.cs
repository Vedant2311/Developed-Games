using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformcontroller : MonoBehaviour {
    public List<GameObject> defaultgrounds;
    private List<GameObject> grounds;
    public Vector3 temppos1;
    public Vector3 temppos2;
	// Use this for initialization
	void Start () {
        this.grounds = new List<GameObject>();
        for(int i = 0; i < 8; i++)
        {
            grounds.Add(defaultgrounds[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z - grounds[0].transform.position.z > 20)
        {
            GameObject temp = grounds[0];
            grounds.RemoveAt(0);
            grounds.Add(temp);
            Vector3 temppos = grounds[6].transform.position;
            temppos.z += 30f;
            temp.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            temp.transform.position = temppos;
            temp.transform.GetChild(0).gameObject.SetActive(true);
            temp.transform.GetChild(1).gameObject.SetActive(true);
            temppos1 = temp.transform.GetChild(0).gameObject.transform.position;
            temppos2 = temp.transform.GetChild(1).gameObject.transform.position;
            temppos1.x = -2.5f* Random.Range(-1, 2);
            temppos2.x = -2.5f* Random.Range(-1, 2);
            temp.transform.GetChild(0).gameObject.transform.position = temppos1;
            temp.transform.GetChild(1).gameObject.transform.position = temppos2;
        }
	}
}
