using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Variables
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public Progression progression;

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
    public AudioClip Airbud;

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

    void Start() {
        progression = GameObject.FindGameObjectWithTag("Player").GetComponent<Progression>();
        if (progression != null) {
            if (progression.difficulty == 1) {
                musicSource.clip = BGM_LvL1;
            }
            if (progression.difficulty == 2) {
                musicSource.clip = BGM_LvL2;
            }
            if (progression.difficulty == 3) {
                musicSource.clip = BGM_LvL3;
            }
        } else {
            musicSource.clip = BGM_LvL1;
            //musicSource.clip = BGM_LvL2;
            //musicSource.clip = BGM_LvL3;
        }
        musicSource.Play();
    }

    void Update () {
        /*if (progression.difficulty == 1)
        {
            musicSource.clip = BGM_LvL1;
        }
        if (progression.difficulty == 2)
        {
            musicSource.clip = BGM_LvL2;
        }
        if (progression.difficulty == 3)
        {
            musicSource.clip = BGM_LvL3;
        }
        musicSource.Play();*/
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