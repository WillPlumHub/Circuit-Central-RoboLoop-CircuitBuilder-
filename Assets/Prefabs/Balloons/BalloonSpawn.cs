using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour {

    #region Variables
    [Header("Balloon Trigger Values")]
    public float chance = 1;
    public float odds;
    public float threshold = 10f; 
    float timePassed = 0f;
    
    [Header("References")]
    public GameObject balloon;
    public GameObject spawn;
    #endregion

    void Update() {
        chance += Time.deltaTime / odds;

        timePassed += Time.deltaTime;
        if (timePassed > 3f) {
            odds = Random.Range(1, 9);
            timePassed = 0f;
        }
        
        if (chance > threshold) {
            Instantiate(balloon, spawn.transform.position, spawn.transform.rotation);
            chance = 1;
        }
    }
}