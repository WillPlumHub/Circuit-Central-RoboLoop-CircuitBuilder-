using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float firingSpeed;
    public float hitDespawnTime;
    public float missDespawnTime;
    public bool inMotion;

    void Awake() {
        inMotion = true;
    }

    void Update() {
        if (inMotion) {
            this.gameObject.transform.Translate(Vector3.right * firingSpeed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(gameObject, hitDespawnTime);
            inMotion = false;
        }
        else {
                Destroy(this.gameObject, missDespawnTime);
        }
    }
}
