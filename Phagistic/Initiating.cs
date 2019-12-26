using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Initiating : MonoBehaviour {
    public float StartingHealth = 100f;

    public Image FadeImage;
    public Image FadeImage1;

    public TextMeshProUGUI HighScoreText;

    public GameObject VolumeON;
    public GameObject VolumeOFF;
    public AudioSource BackgroundMusic;
    public float startTime = 0f;
    public float EndTime = 12f ;
    public GameObject mainMenu;
    public GameObject CreditsMenu;
    public GameObject[] HowToMenu;
    public AudioSource Click;

    public GameObject Holder;
    private NewFading OtherFading;
    private NewFading2 OtherFading2;

    private void Awake()
    {
        OtherFading = Holder.GetComponent<NewFading>();
        OtherFading2 = Holder.GetComponent<NewFading2>();
        BackgroundMusic.volume = 0.4f;
        Click.volume = 0.7f;

        int HighScore = PlayerPrefs.GetInt("HighScore");

        HighScoreText.SetText("High Score:{0}", HighScore);

        PlayerPrefs.SetInt("Boss_Restart", 0);
        PlayerPrefs.SetInt("NoDamage", 0);
        PlayerPrefs.SetInt("BossLevel1", 1);
        PlayerPrefs.SetInt("BossLevel", 1);
        PlayerPrefs.SetInt("Timings", 0);
        PlayerPrefs.SetFloat("Score", StartingHealth);

        StartCoroutine(Fading());
        PlayerPrefs.SetInt("VolumeOn", 1);
        PlayerPrefs.SetInt("OverPlay", 0);
        VolumeOFF.SetActive(true);
        VolumeON.SetActive(false);
        BackgroundMusic.time = startTime;

        mainMenu.SetActive(true);
        CreditsMenu.SetActive(false);

        for (int i = 0; i < HowToMenu.Length; i++)
        {
            HowToMenu[i].SetActive(false);
        }

    }

    IEnumerator Fading()
    {

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





    private void Update()
    {

        if (BackgroundMusic.time > EndTime)
        {
            BackgroundMusic.time = startTime;
        }
    }


}
