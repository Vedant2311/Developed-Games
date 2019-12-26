using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewTimer : MonoBehaviour {

    public TextMeshProUGUI TimerText;
   [HideInInspector] public int Timings;
    [HideInInspector] public int Timings1;

    public float Wait = 1f;

    public GameObject Holder;
    private ManagingScripts2 OtherScript;

    public GameObject Holder1;
    private OtherScorer NewOtherScorer;


    void Start()
    {
        NewOtherScorer = Holder1.GetComponent<OtherScorer>();

        Timings = PlayerPrefs.GetInt("Timings");
        TimerText.SetText("Time: {0} sec", Timings);
        OtherScript = Holder.GetComponent<ManagingScripts2>();

        StartCoroutine(TimerIsOn());
    }

    IEnumerator TimerIsOn()
    {
        while (true)
        {

            if (OtherScript.IsRestart2)
            {
                OtherScript.IsRestart2 = !OtherScript.IsRestart2;
                PlayerPrefs.SetInt("Timings", 0);
            }

            yield return new WaitForSeconds(Wait);
                        

           
            if (OtherScript.IsRestart2)
            {
                OtherScript.IsRestart2 = !OtherScript.IsRestart2;
                PlayerPrefs.SetInt("Timings", 0);
            }

            Timings += 1;
            PlayerPrefs.SetInt("Timings", Timings);
            TimerText.SetText("Time: {0} sec", Timings);


            if (NewOtherScorer.IsGameOver)
            {
                Timings1 = Timings;
                break;
            }

        }
    }

}
