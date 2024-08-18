using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    #region Variables
    [Header("Basics")]
    public bool inMotion;
    public bool player;
    public float firingSpeed;
    
    [Header("Despawn Times")]
    public float hitDespawnTime;
    public float missDespawnTime;
    #endregion

    void Awake() {
        inMotion = true;
    }

    void Update() {
        if (inMotion) {
            if (player) {
                this.gameObject.transform.Translate(Vector3.right * firingSpeed * Time.deltaTime);
            } else {
                this.gameObject.transform.Translate(Vector3.left * firingSpeed * Time.deltaTime);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if((player && collision.gameObject.tag == "Enemy") || (!player && collision.gameObject.tag == "Robot")) {
            Destroy(gameObject, hitDespawnTime);
            inMotion = false;
        }
        else {
                Destroy(this.gameObject, missDespawnTime);
        }
    }
}
