using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverMechanic : MonoBehaviour
{
    Progression progression;
    void Start()
    {
        progression = FindObjectOfType<Progression>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        progression.encounters[progression.currEnemyRef].GetComponent<ItemDrop>().dropBoost += 0.05f;
    }
}
