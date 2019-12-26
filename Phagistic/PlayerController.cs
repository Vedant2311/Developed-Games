using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject GameOverMenu;

    public AudioSource Explode;
    public AudioSource Laser;

    public int FinalLevel;

    public GameObject ScoreHolder;
    private Scorer OtherScorer;

    public Image FadeImage;

    public Scorer MyScorer;

    private float AspectRatio;
    private float X0;
    public float Y0= 4.4f;
    public Vector3 initPos;

    public float Repair = 20f;

    private int BossLevel;
    public float Amount;

    private void Start()
    {
        OtherScorer = ScoreHolder.GetComponent<Scorer>();
        BossLevel = PlayerPrefs.GetInt("BossLevel");
  
        PlayerPrefs.SetInt("NoDamage", 0);

        Vector3 Delta = new Vector3(0.05f, 0f, 0f);
        Vector3 Initial = new Vector3(1f, 1f, 1f);

        if (BossLevel <= FinalLevel + 1)
            transform.localScale = Initial - Delta * (BossLevel - 1);

        else
            MyScorer.Damage += MyScorer.Damage + (Amount * (BossLevel - (FinalLevel + 1)) );
        
        PlayerPrefs.SetInt("IsBoss", 0);
       
        AspectRatio = Screen.currentResolution.width / Screen.currentResolution.height;
        X0 = AspectRatio * Y0;
        initPos = new Vector3(0f, -2.4f, 0f);
        transform.position = initPos;
    }

    private void OnMouseDrag()
    {
        float mouseposition = Input.mousePosition.x;
        Vector3 mousePos = new Vector3(mouseposition, -2.4f, 10f);
        Vector3 objectposition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 objectPos = new Vector3(objectposition.x, -2.4f, objectposition.z);

        if (objectPos.x <= -X0)
            objectPos.x = -X0;
        if (objectPos.x >= X0)
            objectPos.x = X0;

        transform.position = objectPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "obstacle")
        {
            
            Explode.Play();
        }


        if (collision.tag == "Recombinase") {

            
            
            OtherScorer.CurrentHealth = OtherScorer.CurrentHealth + Repair;
            PlayerPrefs.SetFloat("Score", OtherScorer.CurrentHealth);
            OtherScorer.HealthBar.value = OtherScorer.CurrentHealth;
            OtherScorer.FillImage.color = Color.Lerp(OtherScorer.ZeroHealth, OtherScorer.FullHealth, OtherScorer.CurrentHealth / OtherScorer.StartHealth);

        }
    }

   


}
