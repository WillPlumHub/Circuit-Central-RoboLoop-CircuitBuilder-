using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float firingSpeed;
    public float despawnTime;
    
    void Start() {
        transform.Translate(Vector2.right * firingSpeed * Time.deltaTime);
        Destroy(gameObject, despawnTime);
    }
}
