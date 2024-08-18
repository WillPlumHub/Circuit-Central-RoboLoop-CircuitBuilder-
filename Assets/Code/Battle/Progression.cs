using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour {

    public float difficulty = 1;
    public List<GameObject> encounters = new List<GameObject>();
    public float timer = 0;
    public bool active;

    void Start() {
        
    }

    void Update() {
        if (active) {
            timer += Time.deltaTime;
        }
    }
}
