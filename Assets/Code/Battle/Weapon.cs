using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float elementalBonus = 1.5f;
    public string elementalEffect;
    public int Level = 1;
    public float health = 1;
    public float damage;
    public GameObject projectile;
    public Transform spawnPoint;
    public Transform stallPoint;
    public float firingRate = 1;
    public float numShotsPerSpark = 5;
    public Enemy enemy;
    public bool sparkDelay;
    public float delayTime;
    public GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(shoot());
        if (sparkDelay && delayTime > 0) {
            StartCoroutine(delay());
        }
    }

    IEnumerator shoot() {
        for (int i = 0; i < numShotsPerSpark * Level; i++) {
            yield return new WaitForSeconds(firingRate / Level);
            Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);

            if (enemy.element == elementalEffect) {
                enemy.health -= damage * elementalBonus;
            } else {
                enemy.health -= damage;
            }

            
        }
    }

    IEnumerator delay() {
        player.GetComponent<SparkMove>().moving = false;
        player.GetComponent<SparkMove>().Spark.transform.position = stallPoint.position;
        yield return new WaitForSeconds(delayTime);
        player.GetComponent<SparkMove>().moving = true;
    }

    private void Update() {
        health *= Level;
        if (health <= 0) {
            //play destroy anim
            Destroy(gameObject);
        }
    }
}