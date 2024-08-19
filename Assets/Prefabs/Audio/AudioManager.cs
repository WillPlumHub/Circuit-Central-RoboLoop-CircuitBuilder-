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

    void Start () {
        musicSource.clip = BGM_LvL1;
        musicSource.Play();
    }

}