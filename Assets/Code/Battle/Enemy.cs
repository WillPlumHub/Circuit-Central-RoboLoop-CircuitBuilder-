using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Variables
    [Header("Health")]
    public float health = 1; 
    public string element;

    [Header("Attacking")]
    public bool hostile = true;
    public bool isAttacking;
    public float firingRate = 5;
    public GameObject projectile;
    public Transform spawnPoint;
    
    [Header("Script References")]
    public Progression prog;
    public RobotStatus status;
    public ItemDrop itemDrop;

    AudioManager audioManager;
    #endregion

    void Start()
    {
        prog = FindObjectOfType<Progression>();
        status = FindObjectOfType<RobotStatus>();

    }

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update() {

        if (hostile && health > 0 && spawnPoint != null && isAttacking) {
            StartCoroutine(attacking());
            isAttacking = false;
        }

        if (health <= 0) {
            //send any anim flags
            itemDrop.ItemDrops();
            audioManager.PlaySFX(audioManager.EnemyDeath);
            audioManager.PlaySFX(audioManager.Yippee);
            Destroy(gameObject);
        }
    }

    IEnumerator attacking() {
        GetComponent<Animator>().SetTrigger("IsAttacking");
        yield return new WaitForSeconds(0.2f);
        audioManager.PlaySFX(audioManager.EnemyShot);
        status.RoboHealth--;
        Debug.Log("firing");
        yield return new WaitForSeconds(firingRate / prog.difficulty);
        isAttacking = true;
    }
}
