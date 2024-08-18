using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    #region Variables
    public GameObject Menu;
    public static bool isPaused;
    #endregion

    void Start() {
        Menu.SetActive(false);
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

    void UnpauseGame() {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }
    /*
    public void Options() {
        
    }*/

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
