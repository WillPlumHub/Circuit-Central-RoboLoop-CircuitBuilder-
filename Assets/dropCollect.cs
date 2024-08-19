using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropCollect : MonoBehaviour {

    SpriteRenderer rendererr;
    Rigidbody2D rb;
    public float alphaLower = 0.008f;
    public float minVelocity = -1f;
    public float maxVelocity = 1f;
    public Vector2 randomVelocity;
    public bool done = false;

    void Awake() {
        rendererr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        done = false;
    }

    void Update() {
        if (rb == null ) {
            gameObject.AddComponent<Rigidbody2D>();
            rb = GetComponent<Rigidbody2D>();
        }

        if (!done) {
            push();
            done = true;
        }

        Color oldCol = rendererr.material.color;
        if (oldCol.a > 0) {
            Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - alphaLower);
            rendererr.material.color = newCol;
        } else {
            Destroy(gameObject, 0.2f);
        }
    }

    void push() {
        if (rb != null) {
            randomVelocity = new Vector2(Random.Range(minVelocity, maxVelocity), Random.Range(minVelocity, maxVelocity));
            rb.velocity = randomVelocity;
        } else {
            Debug.LogWarning("Rigidbody2D component not found on the object.");
        }
    }
}