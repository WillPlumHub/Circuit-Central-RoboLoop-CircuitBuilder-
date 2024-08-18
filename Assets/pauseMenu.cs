using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    #region Variables
    public GameObject Menu;
    public GameObject OptionMenu;
    public static bool isPaused;
    #endregion

    void Start() {
        Menu.SetActive(false);
        OptionMenu.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                UnpauseGame();
            } else {
                PauseGame();
            }
        }
    }

    void PauseGame() {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;
    }

    public void UnpauseGame() {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void OptionEnter() {
        Menu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void OptionExit() {
        Menu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
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
}
