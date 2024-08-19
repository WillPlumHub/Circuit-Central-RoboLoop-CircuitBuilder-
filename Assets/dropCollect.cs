using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropCollect : MonoBehaviour {

    SpriteRenderer rendererr;
    public float alphaLower = 0.001f;

    void Awake() {
        
    }

    void Update() {
        if (rendererr == null) {
            rendererr = GetComponent<SpriteRenderer>();
        }

        Color oldCol = rendererr.material.color;
        if (oldCol.a > 0) {
            Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - alphaLower);
            rendererr.material.color = newCol;
        } else {
            Destroy(gameObject, 0.2f);
        }
    }
}
