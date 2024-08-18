using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

    #region Variables
    public static bool isPaused;
    public GameObject Menu;
    
    [Header("Component References")]
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;
    #endregion

    void Start() {
        spriteRenderer = Menu.GetComponent<SpriteRenderer>(); spriteRenderer.enabled = false;
        boxCol = Menu.GetComponent<BoxCollider2D>(); boxCol.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    void PauseGame() {
        if (isPaused) {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            spriteRenderer.enabled = true;
            if (spriteRenderer.sortingOrder == 0 ) spriteRenderer.sortingOrder = 1;
            boxCol.enabled = true;
        } else {
            Time.timeScale = 1;
            AudioListener.pause = false;
            spriteRenderer.enabled = false;
            boxCol.enabled = false;
        }
    }
}
