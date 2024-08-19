using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Variables
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Music")]
    public float musicChoice;
    public AudioClip BGM_LvL1;
    public AudioClip BGM_LvL2;
    public AudioClip BGM_LvL3;

    [Header("General SFX")]
    public AudioClip Activate;
    public AudioClip Yippee;
    public AudioClip ItsOver;
    public AudioClip WeDidIt;
    public AudioClip Wonderful;
    public AudioClip MenuSelect;

    [Header("Spark SFX")]
    public AudioClip SparkLaunch;
    public AudioClip SparkEnd;
    public AudioClip SparkMoving;
    public AudioClip SparkDeath;

    [Header("Roboi SFX")]
    public AudioClip RoboiDeath;

    [Header("Mod SFX")]
    public AudioClip WeaponDeath;
    public AudioClip WeaponFiring;
    public AudioClip ModPlace;

    [Header("Battle SFX")]
    public AudioClip EnemyShot;
    public AudioClip EnemyDeath;
    public AudioClip CardSelect;
    public AudioClip BalloonPop;
    public AudioClip BalloonMove;
    #endregion

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
    audioManager.PlaySFX(audioManager.SFXVARNAME);
     */
}