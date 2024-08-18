using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour {

    #region Variables
    [Header("Run Variables")]
    public float difficulty = 1;

    [Header("Enemy List")]
    public List<GameObject> encounters = new List<GameObject>();

    [Header("Timer")]
    public float timer = 0;
    public bool active;
    #endregion

    void Start() {
        
    }

    void Update() {
        if (active) {
            timer += Time.deltaTime;
        }
    }
}
