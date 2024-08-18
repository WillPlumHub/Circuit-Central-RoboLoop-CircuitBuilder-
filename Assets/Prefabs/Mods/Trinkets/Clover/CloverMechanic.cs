using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverMechanic : MonoBehaviour
{
    ItemDrop itemDrop;
    void Start()
    {
        itemDrop = FindObjectOfType<ItemDrop>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        itemDrop.dropBoost +=0.05f;
    }
}
