using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    #region Variables
    [Header("Basics")] 
    public float health = 1;
    public int Level = 1;
    public bool levelUp = false;

    [Header("Damage")]
    public float damage;
    public float elementalBonus = 1.5f;
    public string elementalEffect;
    public Enemy enemy;
    public Camera BattleCam;

    [Header("Shooting")]
    public GameObject projectile;
    public Transform spawnPoint;
    public float firingRate = 1;
    public float numShotsPerSpark = 5;

    [Header("Spark Stalling")]
    public Transform stallPoint;
    public bool sparkDelay;
    public float delayTime;
    public GameObject player;
    #endregion

    public RobotStatus RoboStats;

    void Start() {
        player = GameObject.FindWithTag("Player");
        Camera[] cameras = Camera.allCameras;
        foreach (Camera camera in cameras) {
            if (camera.name == "BattleCam") {
                BattleCam = camera;
                    }
                }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(shoot());
        if (sparkDelay && delayTime > 0) {
            StartCoroutine(delay());
        }
    }

    IEnumerator shoot() {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        for (int i = 0; i < numShotsPerSpark * Level; i++) {
            yield return new WaitForSeconds(firingRate / Level);
            Debug.Log("Status: " + projectile.name + " " + spawnPoint.position + " " + projectile.transform.rotation);
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


        //player.GetComponent<SparkMove>().Spark.transform.position = stallPoint.position;
        if (stallPoint != null) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, stallPoint.position, 2);
        }

        yield return new WaitForSeconds(delayTime);
        player.GetComponent<SparkMove>().moving = true;
    }

    private void Update() {
        if (levelUp) {
            health *= Level;
            Level++;
            levelUp = false;
        }
        
        if (health <= 0) {
            //play destroy anim
            Destroy(gameObject);
        }
    }
}