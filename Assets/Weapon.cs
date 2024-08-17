using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int Level;
    public float health;
    public GameObject projectile;
    public Transform spawnPoint;
    public float firingRate = 1;
    public float numShotsPerSpark = 5;

    public void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(shoot());
    }

    IEnumerator shoot() {
        for (int i = 0; i < numShotsPerSpark; i++) {
            Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);
            yield return new WaitForSeconds(firingRate);
        }
    }

    private void Update() {
        if (health <= 0) {
            //play destroy anim
            Destroy(gameObject);
        }
    }
}