using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTimeScale : MonoBehaviour {

    void Update() {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;

    }
}
