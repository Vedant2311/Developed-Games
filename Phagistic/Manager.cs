using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public GameObject VolumeON;
    public GameObject VolumeOFF;
    public AudioSource sources1;
    public AudioSource sources2;

    public GameObject mainMenu;
    public GameObject CreditsMenu;
    public GameObject[] HowToMenu;

    public GameObject HighScoreText;

    public GameObject Holder;
    private NewFading OtherFading;

    public Image FadeImage;

    private void Start()
    {
        OtherFading = Holder.GetComponent<NewFading>();
    }


    public void PlayGame()
    {

        sources2.Play();
            sources1.volume = 0f;


        StartCoroutine(Fading());
    }

    IEnumerator Fading() {
       
        FadeImage.gameObject.SetActive(true);

        OtherFading.Fade(true, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("main");

    }


    public void OnclickVolOn()
    {
        VolumeOFF.SetActive(true);
        VolumeON.SetActive(false);

        PlayerPrefs.SetInt("VolumeOn", 1);
        sources1.volume = 0.4f;
        sources2.volume = 0.7f;


    }

    public void ONclickvolOff()
    {
        PlayerPrefs.SetInt("VolumeOn", 0);
        VolumeOFF.SetActive(false);
        VolumeON.SetActive(true);
        sources1.volume = 0.0f;
        sources2.volume = 0.0f;

    }

    public void OnclickCredits()
    {
        sources2.Play();
        HighScoreText.SetActive(false);
        mainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        for (int i = 0; i < HowToMenu.Length; i++)
        {
            HowToMenu[i].SetActive(false);
        }

    }

    public void OnclickTut()
    {
        HighScoreText.SetActive(false);
        sources2.Play();
        mainMenu.SetActive(false);
        CreditsMenu.SetActive(false);

        HowToMenu[0].SetActive(true);
    }

    public void OnclickBack()
    {
        HighScoreText.SetActive(true);
        sources2.Play();
        mainMenu.SetActive(true);
        CreditsMenu.SetActive(false);

        for (int i = 0; i < HowToMenu.Length; i++)
        {
            HowToMenu[i].SetActive(false);
        }
    }

    public void OnclickRight0()
    {
        sources2.Play();
        HowToMenu[0].SetActive(false);
        HowToMenu[1].SetActive(true);

    }

    public void OnclickRight1()
    {
        sources2.Play();
        HowToMenu[1].SetActive(false);
        HowToMenu[2].SetActive(true);

    }

    public void OnclickRight2()
    {
        sources2.Play();
        HowToMenu[2].SetActive(false);
        HowToMenu[3].SetActive(true);

    }

    public void OnclickRight3()
    {
        sources2.Play();
        HowToMenu[3].SetActive(false);
        HowToMenu[4].SetActive(true);

    }

    public void OnclickRight4()
    {
        sources2.Play();
        HowToMenu[4].SetActive(false);
        HowToMenu[5].SetActive(true);

    }

    public void OnclickRight5()
    {
        sources2.Play();
        HowToMenu[5].SetActive(false);
        HowToMenu[6].SetActive(true);

    }

    public void OnclickRight6()
    {
        sources2.Play();
        HowToMenu[6].SetActive(false);
        HowToMenu[7].SetActive(true);

    }

    public void OnclickRight7()
    {
        sources2.Play();
        HowToMenu[7].SetActive(false);
        HowToMenu[8].SetActive(true);

    }

    public void OnclickRight8()
    {
        sources2.Play();
        HowToMenu[8].SetActive(false);
        HowToMenu[9].SetActive(true);

    }
    public void OnclickRight9()
    {
        sources2.Play();
        HowToMenu[9].SetActive(false);
        HowToMenu[10].SetActive(true);

    }

    public void OnclickRight10()
    {
        sources2.Play();
        HowToMenu[10].SetActive(false);
        HowToMenu[11].SetActive(true);

    }

    public void OnclickRight11()
    {
        sources2.Play();
        HowToMenu[11].SetActive(false);
        HowToMenu[12].SetActive(true);

    }

    public void OnclickLeft1()
    {
        sources2.Play();
        HowToMenu[1].SetActive(false);
        HowToMenu[0].SetActive(true);

    }

    public void OnclickLeft2()
    {
        sources2.Play();
        HowToMenu[2].SetActive(false);
        HowToMenu[1].SetActive(true);

    }

    public void OnclickLeft3()
    {
        sources2.Play();
        HowToMenu[3].SetActive(false);
        HowToMenu[2].SetActive(true);

    }

    public void OnclickLeft4()
    {
        sources2.Play();
        HowToMenu[4].SetActive(false);
        HowToMenu[3].SetActive(true);

    }

    public void OnclickLeft5()
    {
        sources2.Play();
        HowToMenu[5].SetActive(false);
        HowToMenu[4].SetActive(true);

    }

    public void Onclickleft6()
    {
        sources2.Play();
        HowToMenu[6].SetActive(false);
        HowToMenu[5].SetActive(true);

    }

    public void OnclickLeft7()
    {
        sources2.Play();
        HowToMenu[7].SetActive(false);
        HowToMenu[6].SetActive(true);

    }

    public void OnclickLeft8()
    {
        sources2.Play();
        HowToMenu[8].SetActive(false);
        HowToMenu[7].SetActive(true);

    }

    public void OnclickLeft9()
    {
        sources2.Play();
        HowToMenu[9].SetActive(false);
        HowToMenu[8].SetActive(true);

    }
    public void OnclickLeft10()
    {
        sources2.Play();
        HowToMenu[10].SetActive(false);
        HowToMenu[9].SetActive(true);

    }

    public void OnclickLeft11()
    {
        sources2.Play();
        HowToMenu[11].SetActive(false);
        HowToMenu[10].SetActive(true);

    }

    public void OnclickLeft12()
    {
        sources2.Play();
        HowToMenu[12].SetActive(false);
        HowToMenu[11].SetActive(true);

    }


}




