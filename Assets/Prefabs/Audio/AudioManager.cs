using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Music")]
    public float musicChoice;
    public AudioClip BGM_LvL1;
    public AudioClip BGM_LvL2;
    public AudioClip BGM_LvL3;

    [Header("SFX")]
    public AudioClip SparkLaunch;
    public AudioClip Activate;
    public AudioClip Shoot;
    public AudioClip Death;
    public AudioClip Yippee;
    public AudioClip MenuSelect;
    public AudioClip EnemyShot;
    public AudioClip EnemyDeath;

    void Start () {
        musicSource.clip = BGM_LvL1;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    /*
    AudioManager audioManager;
      
    void Awake(){
        audioManager = GameObject.FindObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    audioManager.PlayeSFX(audioManager.SFXVARNAME);
     */
}