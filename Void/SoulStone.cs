using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulStone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //code to inc life
        }
    }
}
