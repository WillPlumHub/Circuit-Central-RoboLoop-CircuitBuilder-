using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool firing = false;

    public void OnTriggerEnter2D(Collider2D collision) {
        firing = true;
    }
}