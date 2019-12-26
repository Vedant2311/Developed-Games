using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public TextMeshProUGUI TimerText;
    [HideInInspector] public int Timings;
    public float Wait = 1f;

    public GameObject ScriptHolder;
    private managingScripts OtherScript;

    public GameObject Holder;
    private Scorer OtherScorer;

    [HideInInspector] public int Timings1;

	// Use this for initialization
	void Start () {
        Timings = PlayerPrefs.GetInt("Timings");
        TimerText.SetText("Time: {0} sec", Timings);

        OtherScorer = Holder.GetComponent<Scorer>();

        OtherScript = ScriptHolder.GetComponent<managingScripts>();
        StartCoroutine(TimerIsOn());
	}
	
	IEnumerator TimerIsOn()
    {
        while (true)
        {
            int Rest = PlayerPrefs.GetInt("Boss_Restart");
            if ((OtherScript.IsRestart1) || (Rest==1))
            {
                TimerText.SetText("Time: {0} sec", 0);
                Timings = 0;
                OtherScript.IsRestart1 = !OtherScript.IsRestart1;
                Rest = 0;
                PlayerPrefs.SetInt("Boss_Restart", 0);
            }
            yield return new WaitForSeconds(Wait);

            if ((OtherScript.IsRestart1) || (Rest == 1))
            {
                TimerText.SetText("Time: {0} sec", 0);
                Timings = 0;
                OtherScript.IsRestart1 = !OtherScript.IsRestart1;
                Rest = 0;
                PlayerPrefs.SetInt("Boss_Restart", 0);
            }

            Timings += 1;
            PlayerPrefs.SetInt("Timings", Timings);
            TimerText.SetText("Time: {0} sec", Timings);

            if (OtherScorer.GameOver)
            {
                Timings1 = Timings;
                break;
            }
           
        }
    }


}
