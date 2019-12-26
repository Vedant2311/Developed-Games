using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallManager : MonoBehaviour {

    public float given;
    private AudioSource Clip;
	// Use this for initialization
	void Start () {
        Clip = GetComponent<AudioSource>();
        StartCoroutine(playAudio());
	}
	
	IEnumerator playAudio()
    {
        yield return new WaitForSeconds(given);
        Clip.Play();
    }
}
