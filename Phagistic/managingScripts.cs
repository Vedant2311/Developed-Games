using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class managingScripts : MonoBehaviour {

    private int BossLevel;

   [HideInInspector] public bool IsRestart;
[HideInInspector]    public bool IsRestart1;

    public AudioSource OnClick;

    public GameObject ScoreMan;
    private Scorer OtherScorer;

    public GameObject Player;
    public Vector3 initpos;

    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI LevelText;

    public GameObject PauseMenu;    
    public GameObject GameOverMenu;

    public GameObject Holder;
    private NewFading OtherFading;
    private NewFading2 OtherFading2;

    public Image FadeImage;
    public Image FadeImage1;

    public Slider Health;
    public Image FillImage;

    public bool GameLoading;

    public float initial_delay = 0.8f;
    public float delta_delay = 0.01f;
    public GameObject obstacles;
    public Transform[] SpawnPoints;

    public void Awake()
    {
        GameLoading = false;
        OtherFading = Holder.GetComponent<NewFading>();
        OtherScorer = ScoreMan.GetComponent<Scorer>();
        OtherFading2 = Holder.GetComponent<NewFading2>();

        int VolOn = PlayerPrefs.GetInt("VolumeOn");

        if (VolOn == 0)
            OnClick.volume = 0f;
        else
            OnClick.volume = 1f;

        StartCoroutine(Fading());

        BossLevel = PlayerPrefs.GetInt("BossLevel");
        LevelText.SetText("{0}A", BossLevel);
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);

    }

    IEnumerator Fading() {

        int Check = PlayerPrefs.GetInt("BossAct");

        if (Check == 1)
        {
            PlayerPrefs.SetInt("BossAct", 0);
            FadeImage.gameObject.SetActive(false);
            FadeImage1.color = Color.white;
            OtherFading2.Fade(false, 1f);
            yield return new WaitForSeconds(1f);
            FadeImage1.gameObject.SetActive(false);
        }

        else
        {
            PlayerPrefs.SetInt("BossAct", 0);
            FadeImage1.gameObject.SetActive(false);
            FadeImage.color = new Color(0, 0, 0);
            OtherFading.Fade(false, 1f);

            yield return new WaitForSeconds(1);
            FadeImage.gameObject.SetActive(false);
        }
    }


    public void OnclickPause() {

        OnClick.Play();
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
      
        
    }

    public void OnclickRestart()
    {
        

        PlayerPrefs.SetInt("OverPlay", 0);
        OnClick.Play();
        int BossLevel;
        int BossLevel1;

        BossLevel1 = PlayerPrefs.GetInt("BossLevel1");
        BossLevel1 = 1;
        PlayerPrefs.SetInt("BossLevel1", BossLevel1);

        BossLevel = PlayerPrefs.GetInt("BossLevel");
        BossLevel = 1;
        PlayerPrefs.SetInt("BossLevel", BossLevel);

        GameOverMenu.SetActive(false);
        IsRestart = true;
        IsRestart1 = true;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Player.transform.position = initpos;
        TimeText.SetText("Time: 0 sec");

        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (Obstacles[i] != null)
            Destroy(Obstacles[i]);
        }

        GameObject[] Streams = GameObject.FindGameObjectsWithTag("BloodStream");

        for (int i = 0; i < Streams.Length; i++)
        {
            if (Streams[i] != null)
                Destroy(Streams[i]);
        }

        GameObject[] Explosions = GameObject.FindGameObjectsWithTag("Explosion");

        for (int i = 0; i < Explosions.Length; i++)
        {
            if (Explosions[i] != null)
                Destroy(Explosions[i]);
        }

        GameObject[] Recombinases = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases.Length; i++)
        {
            if (Recombinases[i] != null)
                Destroy(Recombinases[i]);
        }


        Health.gameObject.SetActive(true);

       
            FillImage.gameObject.SetActive(true);

        OtherScorer.CurrentHealth = 100;
        Health.value = 100;
        FillImage.color = Color.green;

        OtherScorer.GameOver = false;    


        


    }


	
    public void OnclickPlay()
    {
        OnClick.Play();
        Time.timeScale = 1;
        PauseMenu.SetActive(false);


    }

    public void OnclickHome()
    {
        OnClick.Play();
        Time.timeScale = 1;
        GameLoading = true;
        OtherScorer.GameOver = false;
        StartCoroutine(MyFade1());

    }

    IEnumerator MyFade1()
    {
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (Obstacles[i] != null)
                Destroy(Obstacles[i]);
        }

        GameObject[] Streams = GameObject.FindGameObjectsWithTag("BloodStream");

        for (int i = 0; i < Streams.Length; i++)
        {
            if (Streams[i] != null)
                Destroy(Streams[i]);
        }

        GameObject[] Explosions = GameObject.FindGameObjectsWithTag("Explosion");

        for (int i = 0; i < Explosions.Length; i++)
        {
            if (Explosions[i] != null)
                Destroy(Explosions[i]);
        }

        GameObject[] Recombinases = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases.Length; i++)
        {
            if (Recombinases[i] != null)
                Destroy(Recombinases[i]);
        }

        GameObject[] Recombinases1 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases1.Length; i++)
        {
            if (Recombinases1[i] != null)
                Destroy(Recombinases1[i]);
        }

        GameObject[] Recombinases2 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases2.Length; i++)
        {
            if (Recombinases2[i] != null)
                Destroy(Recombinases2[i]);
        }

        GameObject[] Recombinases3 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases3.Length; i++)
        {
            if (Recombinases3[i] != null)
                Destroy(Recombinases3[i]);
        }

        GameObject[] Recombinases4 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases4.Length; i++)
        {
            if (Recombinases4[i] != null)
                Destroy(Recombinases4[i]);
        }

        GameObject[] Recombinases5 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases5.Length; i++)
        {
            if (Recombinases5[i] != null)
                Destroy(Recombinases5[i]);
        }


        GameObject[] Recombinases6 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases6.Length; i++)
        {
            if (Recombinases6[i] != null)
                Destroy(Recombinases6[i]);
        }

        GameObject[] Recombinases7 = GameObject.FindGameObjectsWithTag("Recombinase");

        for (int i = 0; i < Recombinases7.Length; i++)
        {
            if (Recombinases7[i] != null)
                Destroy(Recombinases7[i]);
        }

       
        FadeImage.gameObject.SetActive(true);
        OtherFading.Fade(true, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("mainMenu");
    }



}
