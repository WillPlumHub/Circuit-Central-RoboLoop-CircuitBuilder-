using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    #region Variables
    public GameObject Menu;
    public GameObject OptionMenu;
    public static bool isPaused;
    AudioManager audioManager;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        Menu.SetActive(false);
        OptionMenu.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                OptionExit();
                UnpauseGame();
            } else {
                PauseGame();
            }
        }
    }

    void PauseGame() {
        Menu.SetActive(true);
        SFXPlay();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void UnpauseGame() {
        Menu.SetActive(false);
        SFXPlay();
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void OptionEnter() {
        Menu.SetActive(false);
        SFXPlay();
        OptionMenu.SetActive(true);
    }

    public void OptionExit() {
        Menu.SetActive(true);
        SFXPlay();
        OptionMenu.SetActive(false);
    }

    public void GoToMainMenu() {
        SFXPlay();
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void DAnim() {
        Menu.GetComponent<Animator>().SetTrigger("ResumeHover");
    }

    public void RAnim() {
        Menu.GetComponent<Animator>().SetTrigger("TitleHover");
    }
    public void LAnim() {
        Menu.GetComponent<Animator>().SetTrigger("OptionHover");
    }

    public void IAnim() {
        Menu.GetComponent<Animator>().SetTrigger("EmptyHover");
    }

    public void SFXPlay() {
        audioManager.PlaySFX(audioManager.MenuSelect);
    }
}
