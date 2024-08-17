using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool firing = false;
    
    
    
    
    

    public GameObject projectile;  // The projectile to spawn
    public Transform spawnPoint;         // The point where the projectile is spawned
    public float firingRate = 1f;      // Time in seconds between each shot
    public float activeDuration = 5f;      // Total duration to fire projectiles


    public void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(shoot());
    }

    private void Update() {
        if (firing == true) {
            
            
            
        }
    }

    IEnumerator shoot() {
        float elapsedTime = 0f;
        //while (elapsedTime < activeDuration) {
            Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);
            yield return new WaitForSeconds(firingRate);
            //elapsedTime += firingRate;
        //}

    }
}