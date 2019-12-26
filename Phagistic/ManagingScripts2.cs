using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ManagingScripts2 : MonoBehaviour
{

    public Image FadeImage;

    [HideInInspector]public bool IsRestart;
    [HideInInspector]  public bool IsRestart1;
    [HideInInspector]  public bool IsRestart2;

    public AudioSource OnClick;

    public GameObject ScoreMan;
    private OtherScorer OtherScorerProto;

    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI LevelText;

    public GameObject PauseMenu;  
    public GameObject GameOverMenu;

    [HideInInspector]public bool GameLoading;

    public GameObject Holder;
    private NewFading2 OtherFading;

    public Slider Health;
    public Image FillImage;

    public bool IsPaused;

    private int BossLevel;
  

    public void Awake()
    {
        GameLoading = false;
        PlayerPrefs.SetInt("Boss_Restart", 0);
        BossLevel = PlayerPrefs.GetInt("BossLevel");
        LevelText.SetText("{0}B", BossLevel);

        IsPaused = false;

        int VolOn = PlayerPrefs.GetInt("VolumeOn");

        if (VolOn == 0)
            OnClick.volume = 0f;
        else
            OnClick.volume = 1f;


        PlayerPrefs.SetInt("BossAct", 1);
        FadeImage.color = Color.white;
        OtherFading = Holder.GetComponent<NewFading2>();
        OtherScorerProto = ScoreMan.GetComponent<OtherScorer>();
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        StartCoroutine(MyFading());

    }

    IEnumerator MyFading() {

        OtherFading.Fade(false, 1.2f);
        yield return new WaitForSeconds(1.2f);
        FadeImage.gameObject.SetActive(false);

    }


    public void OnclickPause()
    {
        OnClick.Play();
        IsPaused = true;

        Time.timeScale = 0;
        PauseMenu.SetActive(true);


    }

    public void OnclickRestart()
    {
        PlayerPrefs.SetInt("TImings", 0);
        IsPaused = false;
        OnClick.Play();
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);

        PlayerPrefs.SetInt("Boss_Restart", 1);

        IsRestart = true;
        IsRestart1 = true;
        IsRestart2 = true;

        int BossLevel;
        int BossLevel1;
        GameLoading = true;
        BossLevel = PlayerPrefs.GetInt("BossLevel");
        BossLevel = 1;
        PlayerPrefs.SetInt("BossLevel", BossLevel);

        BossLevel1 = PlayerPrefs.GetInt("BossLevel1");
        BossLevel1 = 1;
        PlayerPrefs.SetInt("BossLevel1", BossLevel1);

        Time.timeScale = 1;

        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("SmallBoss");
        
        for (int i = 0; i < Obstacles.Length; i++)
        {
            if (Obstacles[i] != null)
                Destroy(Obstacles[i]);
        }

        GameObject[] Obstacles1 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles1.Length; i++)
        {
            if (Obstacles1[i] != null)
                Destroy(Obstacles1[i]);
        }



        PlayerPrefs.SetInt("Timings", 0);
        PlayerPrefs.SetFloat("Score", 100f);

        StartCoroutine(MyFade());
                               
    }

    IEnumerator MyFade() {

        GameObject[] Obstacles11 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstacles11.Length; i++)
        {
            if (Obstacles11[i] != null)
                Destroy(Obstacles11[i]);
        }

        GameObject[] Obstacles12 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles12.Length; i++)
        {
            if (Obstacles12[i] != null)
                Destroy(Obstacles12[i]);
        }

        GameObject[] Obstacles21 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstacles21.Length; i++)
        {
            if (Obstacles21[i] != null)
                Destroy(Obstacles21[i]);
        }

        GameObject[] Obstacles22 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles22.Length; i++)
        {
            if (Obstacles22[i] != null)
                Destroy(Obstacles22[i]);
        }

        FadeImage.gameObject.SetActive(true);
        OtherFading.Fade(true, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("main");
    }


    public void OnclickPlay()
    {
        IsPaused = false;
        OnClick.Play();
        Time.timeScale = 1;
        PauseMenu.SetActive(false);


    }

    public void OnclickHome()
    {
        GameLoading = true;
        IsPaused = false;
        OnClick.Play();
        Time.timeScale = 1;      
        OtherScorerProto.IsGameOver = false;

        GameObject[] Obstacles31 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstacles31.Length; i++)
        {
            if (Obstacles31[i] != null)
                Destroy(Obstacles31[i]);
        }

        GameObject[] Obstacles112 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles112.Length; i++)
        {
            if (Obstacles112[i] != null)
                Destroy(Obstacles112[i]);
        }

        GameObject[] Obstacles212 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstacles212.Length; i++)
        {
            if (Obstacles212[i] != null)
                Destroy(Obstacles212[i]);
        }

        GameObject[] Obstacles121 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles121.Length; i++)
        {
            if (Obstacles121[i] != null)
                Destroy(Obstacles121[i]);
        }


        StartCoroutine(MyFade1());
    }

    IEnumerator MyFade1()
    {

        GameObject[] Obstaclesa31 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstaclesa31.Length; i++)
        {
            if (Obstaclesa31[i] != null)
                Destroy(Obstaclesa31[i]);
        }

        GameObject[] Obstaclesa112 = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstaclesa112.Length; i++)
        {
            if (Obstaclesa112[i] != null)
                Destroy(Obstaclesa112[i]);
        }

        GameObject[] Obstaclesa212 = GameObject.FindGameObjectsWithTag("SmallBoss");

        for (int i = 0; i < Obstaclesa212.Length; i++)
        {
            if (Obstaclesa212[i] != null)
                Destroy(Obstaclesa212[i]);
        }

        GameObject[] Obstacles121a = GameObject.FindGameObjectsWithTag("Guard");

        for (int i = 0; i < Obstacles121a.Length; i++)
        {
            if (Obstacles121a[i] != null)
                Destroy(Obstacles121a[i]);
        }


        FadeImage.gameObject.SetActive(true);
        OtherFading.Fade(true, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("mainMenu");
    }






}
