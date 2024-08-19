using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSFX : MonoBehaviour {

    AudioManager audioManager;

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void PlayerSFX() {
        audioManager.PlaySFX(audioManager.Pistol);
    }
}