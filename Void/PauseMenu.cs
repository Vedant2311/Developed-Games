using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;// || ye wala
    public string scene;
    public Color loadToColor = Color.white;

    public void press() {
        if (!isPaused){//if game is running and I wanna stop it
            isPaused = true;
            pauseButton.SetActive(false);
            Pause();
        }
        else {//game is paused and will run again when this block is to be executed
            isPaused = false;
            pauseButton.SetActive(true);
            Resume();
        }
    }

    void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Menu() {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu");
        Initiate.Fade(scene,loadToColor,1f);
    }

    public void Quit() {
        Time.timeScale = 1f;
        Debug.Log("Quiting game");
        Application.Quit();
    }
}