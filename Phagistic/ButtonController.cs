using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour {

    public GameObject RotHolder;
    public GameObject Guard;
    public Transform Origin;
    public float AngularSpeed;

    public GameObject Holder;
    private ManagingScripts2 Otherscript;

    public GameObject Holder1;
    private OtherScorer NewScorer;

    public AudioSource Thunder;

    public void Awake()
    {
        NewScorer = Holder1.GetComponent<OtherScorer>();
        Otherscript = Holder.GetComponent<ManagingScripts2>();
    }

    public void Onclickleft()
    {
                Quaternion Target = Quaternion.Euler(0, 0, 60);
                RotHolder.transform.rotation = Quaternion.Slerp(RotHolder.transform.rotation, Target, AngularSpeed * Time.deltaTime);
 
    }

    public void OnclickRight()
    {
       
            Quaternion Target = Quaternion.Euler(0, 0, -60);
            RotHolder.transform.rotation = Quaternion.Slerp(RotHolder.transform.rotation, Target, AngularSpeed * Time.deltaTime);
       
    }

    public void OnclickThunder()
    {
        if ((!Otherscript.IsPaused) && (!NewScorer.IsGameOver))
        {
            Instantiate(Guard, Origin.position, Origin.rotation);
            Thunder.Play();
        }
    }


}
