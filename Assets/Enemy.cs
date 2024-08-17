using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string element;
    public float health = 1;
    public List<GameObject> drops = new List<GameObject>();
    public Progression prog;
    public float firingRate = 1;
    public GameObject projectile;
    public Transform spawnPoint;
    public bool hostile;

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
