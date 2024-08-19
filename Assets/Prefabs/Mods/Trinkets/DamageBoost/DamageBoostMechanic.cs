using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    ModifierHandler modifierHandler;
    public int level = 1;
    public int damageBoostAmount = 2;

    void Start()
    {
        modifierHandler = FindObjectOfType<ModifierHandler>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        modifierHandler.DamageBoost += (damageBoostAmount + ((level - 1) * 3));
    }
}
