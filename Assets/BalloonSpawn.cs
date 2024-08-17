using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour {

    public bool send;
    public GameObject balloon;
    public GameObject spawn;

    void Update()
    {
        if (send)
        {
            Instantiate(balloon, spawn.transform.position, spawn.transform.rotation);
            send = false;
        }
    }
}
