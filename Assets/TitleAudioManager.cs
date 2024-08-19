using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudioManager : MonoBehaviour {

    #region Variables
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Music")]
    public AudioClip BGM_Title;

    [Header("General SFX")]
    public AudioClip MenuSelect;
    #endregion

    void Awake() {
        if (musicSource != null && BGM_Title != null) {
            musicSource.clip = BGM_Title;
            musicSource.Play();
        }
        else {
            Debug.LogWarning("MusicSource or bgmTitle is not assigned.");
        }
    }

    public void PlaySFX(AudioClip clip) {
        if (SFXSource != null && clip != null) {
            SFXSource.PlayOneShot(clip);
        }
        else {
            Debug.LogWarning("SFXSource or AudioClip is not assigned.");
        }

    }
}