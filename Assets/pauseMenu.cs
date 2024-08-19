using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    #region Variables
    public GameObject Menu;
    public GameObject OptionMenu;
    public GameObject ItemAmounts;
    public static bool isPaused;
    AudioManager audioManager;
    public GameObject healthBar;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        Menu.SetActive(false);
        ItemAmounts.SetActive(true);
        OptionMenu.SetActive(false);
        healthBar = GameObject.Find("HealthBar");
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
        Time.timeScale = 0f;
        Menu.SetActive(true);
        ItemAmounts.SetActive(false);
        healthBar.SetActive(false);
        SFXPlay();
        isPaused = true;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f; 
        Menu.SetActive(false);
        ItemAmounts.SetActive(true);
        healthBar.SetActive(true);
        SFXPlay();
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
