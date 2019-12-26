using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float initial_delay ;
    public float delta_delay = 0.01f;
    public GameObject obstacles;
    public Transform[] SpawnPoints;

    public float FinalDelay;

    public GameObject Recombinase;
    public float SpawnTime;
    public float Error = 0.1f;

    public GameObject ScoreHolder;
    private Scorer OtherScorer;

    

    public GameObject Manager;
    private managingScripts OtherManager;

    
    // Use this for initialization
    void Start() {
       
        OtherScorer = ScoreHolder.GetComponent<Scorer>();
        OtherManager = Manager.GetComponent<managingScripts>();
        StartCoroutine(SpawnThem());
    }



    IEnumerator SpawnThem() {

        yield return new WaitForSeconds(1f);
        float delay = initial_delay;

        while (true) {

            if ((!OtherScorer.GameOver) && (!OtherManager.GameLoading))
            {
               
                {
                    int SpawnIndex = Random.Range(0, SpawnPoints.Length);
                    Transform SpawnPoint = SpawnPoints[SpawnIndex];

                    if (Mathf.Abs(delay - SpawnTime) <= Error)
                        Instantiate(Recombinase, SpawnPoint.position, SpawnPoint.rotation);
                    else
                        Instantiate(obstacles, SpawnPoint.position, SpawnPoint.rotation);

                    yield return new WaitForSeconds(delay);

                    if (delay>=FinalDelay)
                          delay += delta_delay;

                    if (OtherManager.IsRestart)
                    {
                        OtherManager.IsRestart = !OtherManager.IsRestart;
                        delay = initial_delay;
                    }
                }
            }

            if (OtherManager.GameLoading) {

                yield return new WaitForSeconds(2f);

            }


        }






    }


}
