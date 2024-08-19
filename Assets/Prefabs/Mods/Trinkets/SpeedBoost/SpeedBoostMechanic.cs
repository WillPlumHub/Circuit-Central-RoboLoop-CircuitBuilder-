using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostMechanic : MonoBehaviour {

    SparkMove sparkMove;
    public int level = 1;
    public int boostAmount = 2;

    void Start() {
        sparkMove = GameObject.FindGameObjectWithTag("Player").GetComponent<SparkMove>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        sparkMove.boostMult = boostAmount;
    }
}