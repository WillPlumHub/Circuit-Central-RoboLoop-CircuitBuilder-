using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour {

    #region Variables
    [Header("Basics")]
    public bool send;
    public GameObject balloon;
    public GameObject spawn;
    #endregion

    void Update()
    {
        if (send)
        {
            Instantiate(balloon, spawn.transform.position, spawn.transform.rotation);
            send = false;
        }
    }
}
