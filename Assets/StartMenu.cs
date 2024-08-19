using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    #region Variables
    public GameObject Menu;
    public GameObject OptionMenu;
    public TitleAudioManager audioManager;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<TitleAudioManager>();
    }

    void Start() {
        Menu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void StartGame() {
        SFXPlay();
        //play anim
        SceneManager.LoadScene("temp 2");
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

    public void SFXPlay() {
        audioManager.PlaySFX(audioManager.MenuSelect);
    }
}
