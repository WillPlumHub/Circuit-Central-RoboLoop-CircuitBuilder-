using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Variables
    [Header("Health")]
    public float health = 1; 
    public string element;

    [Header("Attacking")]
    public bool hostile;
    public bool isAttacking;
    public float firingRate = 1;
    public GameObject projectile;
    public Transform spawnPoint;
    
    [Header("Script References")]
    public Progression prog;
    public RobotStatus status;
    public ItemDrop itemDrop;
    #endregion

    void Update() {

        if (hostile && health > 0 && spawnPoint != null && isAttacking) {
            StartCoroutine(attacking());
            isAttacking = false;
        }

        if (health <= 0) {
            //send any anim flags
            itemDrop.ItemDrops();
            Destroy(gameObject);
        }
    }

    IEnumerator attacking() {
        status.RoboHealth--;
        Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);
        yield return new WaitForSeconds(firingRate / prog.difficulty);
        isAttacking = true;
    }
}
