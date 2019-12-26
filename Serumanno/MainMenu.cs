using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   

    void start()
    {
       
       
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Timings", 0);

        PlayerPrefs.SetInt("Restart", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    

}
