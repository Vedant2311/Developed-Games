using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Time.timeScale = 0.5f;
            gameObject.SetActive(false);
        }
    }
}
