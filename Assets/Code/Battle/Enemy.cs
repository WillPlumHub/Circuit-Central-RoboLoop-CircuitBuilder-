using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Variables
    [Header("Health")]
    public float health = 1; 
    public string element;

    [Header("Drop List")]
    public List<GameObject> drops = new List<GameObject>();

    [Header("Attacking")]
    public bool hostile; 
    public float firingRate = 1;
    public GameObject projectile;
    public Transform spawnPoint;
    
    [Header("Script References")]
    public Progression prog;

    #endregion

    void Start() {
        if (hostile) {
            StartCoroutine(attacking());
        }
    }

    void Update() {
        if (health <= 0) {
            //send any flags
            //drop drops
            Destroy(gameObject);
        }

    }

    IEnumerator attacking() {
        while (hostile && health > 0 && spawnPoint != null) {
            Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);
            yield return new WaitForSeconds(firingRate / prog.difficulty);
        }
    }
}
