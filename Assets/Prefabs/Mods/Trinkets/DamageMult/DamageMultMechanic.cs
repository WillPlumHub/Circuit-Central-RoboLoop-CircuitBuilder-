using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMultMechanic : MonoBehaviour
{
    ModifierHandler modifierHandler;
    public int level = 1;
    public int damageMultAmount = 2;

    void Start()
    {
        modifierHandler = FindObjectOfType<ModifierHandler>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        modifierHandler.DamageBoost *= (damageMultAmount + (level - 1));
    }
}
