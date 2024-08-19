using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunSFX : MonoBehaviour {

    AudioManager audioManager;

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void PlayerSFX() {
        audioManager.PlaySFX(audioManager.MachineGun);
    }
}