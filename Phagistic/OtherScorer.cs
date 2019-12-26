using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OtherScorer : MonoBehaviour {

    public bool IsGameOver;
    public float MaxHealth = 100f;
    public Slider HealthBar;
    public Image FillImage;
    public Color FullHealth = Color.green;
    public Color ZeroHealth = Color.red;
    [HideInInspector] public float CurrentHealth;
    public float Damage = 2f;

    public GameObject GameOverMenu;
    public AudioSource GameOverMusic;

    public GameObject Holder;
    private NewTimer OtherTimer;
    private int MaxScore;

    public AudioSource Thunder;
    public AudioSource Wind;
    public AudioSource explosion;

    public TextMeshProUGUI HighScoreText;

    // Use this for initialization
    void Start () {

        OtherTimer = Holder.GetComponent<NewTimer>();
        IsGameOver = false;
        
        CurrentHealth = PlayerPrefs.GetFloat("Score");
        HealthBar.value = CurrentHealth;
        FillImage.color = Color.Lerp(ZeroHealth, FullHealth, CurrentHealth / MaxHealth);

        int VolOn = PlayerPrefs.GetInt("VolumeOn");

        if (VolOn == 0)
        {
            Thunder.volume = 0f;
            Wind.volume = 0f;
            explosion.volume = 0f;
            GameOverMusic.volume = 0f;
        }
        else
        {
            Thunder.volume = 0.15f;
            explosion.volume = 0.65f;
            Wind.volume = 1f;
            GameOverMusic.volume = 1f;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SmallBoss")
        {
            if (CurrentHealth >Damage)
                   explosion.Play();
            CurrentHealth = CurrentHealth - Damage;
            PlayerPrefs.SetFloat("Score", CurrentHealth);
            HealthBar.value = CurrentHealth;
            FillImage.color = Color.Lerp(ZeroHealth, FullHealth, CurrentHealth / MaxHealth);

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
                IsGameOver = true;
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
    }
}
