using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour {

    public AudioSource GameOverMusic;

    public bool GameOver = false;
    public float StartHealth = 100f;
    public Slider HealthBar;
    public Image FillImage;
    public Color FullHealth = Color.green;
    public Color ZeroHealth = Color.red;
    [HideInInspector] public float CurrentHealth;
    public float Damage = 2f;

    public GameObject Holder;
    private NewFading2 OtherFading;

    public GameObject GameOverMenu;
    public AudioSource Explosion;
    public GameObject Holder1;
    private Timer OtherTimer;
    private int MaxScore;

    public Image FadeImage;

    public AudioSource Explode;
    public AudioSource Laser;

    public TextMeshProUGUI HighScoreText;

    // Use this for initialization
    void Start () {

        OtherFading = Holder.GetComponent<NewFading2>();
        OtherTimer = Holder1.GetComponent<Timer>();

        int VolOn = PlayerPrefs.GetInt("VolumeOn");

        if (VolOn == 0)
        {
            Laser.volume = 0f;
            Explosion.volume = 0f;
            Explode.volume = 0f;
            GameOverMusic.volume = 0f;
        }
        else
        {
            Laser.volume = 1f;
            Explosion.volume = 0.38f;
            Explode.volume = 0.37f;
            GameOverMusic.volume = 1f;
        }

        CurrentHealth = PlayerPrefs.GetFloat("Score");
        GameOverMenu.SetActive(false);
        GameOver = false;
        

        HealthBar.value = CurrentHealth;
        FillImage.color = Color.Lerp(ZeroHealth, FullHealth, CurrentHealth / StartHealth);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle")
        {
            int NoDamage = PlayerPrefs.GetInt("NoDamage");
            if (NoDamage == 0)
            {
                Explode.Play();
                CurrentHealth = CurrentHealth - Damage;
            }
            PlayerPrefs.SetFloat("Score", CurrentHealth);
            HealthBar.value = CurrentHealth;
            FillImage.color = Color.Lerp(ZeroHealth, FullHealth, CurrentHealth / StartHealth);

            if (HealthBar.value <= 0)
            {
                int PlayOn = PlayerPrefs.GetInt("OverPlay");

                if (PlayOn == 0)
                {
                    PlayOn += 1;
                    GameOverMusic.Play();
                    PlayerPrefs.SetInt("OverPlay", PlayOn);
                }
                HealthBar.gameObject.SetActive(false);
               FillImage.gameObject.SetActive(false);
               GameOver = true;

                GameOverMenu.SetActive(true);
                Time.timeScale = 0;

                MaxScore = PlayerPrefs.GetInt("HighScore");

                if (OtherTimer.Timings1 > MaxScore)
                {
                    PlayerPrefs.SetInt("HighScore", OtherTimer.Timings1);
                    HighScoreText.SetText("High Score!");
                }

                else
                    HighScoreText.SetText("");

            }

        }

        if (collision.tag == "Recombinase")
        {
         
            Laser.Play();
            PlayerPrefs.SetInt("IsBoss", 1);
            PlayerPrefs.SetInt("NoDamage", 1);
            FadeImage.gameObject.SetActive(true);

            GameObject Recombinase = GameObject.FindGameObjectWithTag("Recombinase");

            if (Recombinase != null)
                Destroy(Recombinase);


            StartCoroutine(Fading());

        }



    }

    IEnumerator Fading()
    {
        OtherFading.Fade(true, 1.3f);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("BossScene");

    }



}
