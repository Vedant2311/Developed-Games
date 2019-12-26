using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossSpawner : MonoBehaviour
{
    public AudioSource Laser;

    public Image FadeImage;

    public GameObject[] obstacles;
    public Transform[] SpawnPoints;

    public TextMeshProUGUI Left;
    [HideInInspector]public float Total;

    public GameObject ScoreHolder;
    private OtherScorer NewOtherScorer;

  public   float FinalDelay;

    public GameObject Holder;
    private NewFading2 OtherFading;

    public GameObject ManagingHolder;
    private ManagingScripts2 MyScript;

    public int Delta;

    public int initTotal;
    private float delay;
    private int BossLevel;
    private int BossLevel1;
    public int MaxLevel;

    // Use this for initialization
    void Start()
    {

        BossLevel = PlayerPrefs.GetInt("BossLevel");

        Total = initTotal + ((BossLevel-1) * Delta);
        delay = 1 - ((BossLevel - 1) * 0.05f);

        if (delay <= FinalDelay)
            delay = FinalDelay;

        Left.SetText("Left:{0}", Total);
        NewOtherScorer = ScoreHolder.GetComponent<OtherScorer>();
        OtherFading = Holder.GetComponent<NewFading2>();
        MyScript = ManagingHolder.GetComponent<ManagingScripts2>();
        StartCoroutine(SpawnThem());
    }



    IEnumerator SpawnThem()
    {

        yield return new WaitForSeconds(1f);


        while (true)
        {

            if ((!NewOtherScorer.IsGameOver) && (Total > 0) && (!MyScript.GameLoading))
            {



                int SpawnIndex = Random.Range(0, SpawnPoints.Length);
                Transform SpawnPoint = SpawnPoints[SpawnIndex];


                Instantiate(obstacles[(SpawnIndex * 3) % 6], SpawnPoint.position, SpawnPoint.rotation);

                Total -= 1;
                Left.SetText("Left:{0}", Total);

                yield return new WaitForSeconds(delay);



            }

            else if (MyScript.GameLoading ) {

                yield return new WaitForSeconds(2f);

            }

            else
                break;
        }

        if (Total ==0)
        {
            yield return new WaitForSeconds(1f);

            Laser.Play();
            FadeImage.gameObject.SetActive(true);
            OtherFading.Fade(true, 1.3f);

            yield return new WaitForSeconds(1.3f);
            BossLevel += 1;

            if (BossLevel <= MaxLevel)
                BossLevel1 += 1;
            PlayerPrefs.SetInt("BossLevel", BossLevel);
            PlayerPrefs.SetInt("BossLevel1", BossLevel1);

            SceneManager.LoadScene("main");
 

        }


    }






}



