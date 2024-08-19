using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airbud : MonoBehaviour {

    #region Variables
    RobotStatus robotStats;
    public int level = 1;
    public int barkNum = 1;
    AudioManager audioManager;
    #endregion

    void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(barkOverTime());
    }

    IEnumerator barkOverTime() {
        for(int i = 0; i <= barkNum * level; i++) {
            audioManager.PlaySFX(audioManager.Airbud);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
