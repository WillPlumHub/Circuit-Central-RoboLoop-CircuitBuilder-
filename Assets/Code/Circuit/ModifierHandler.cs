using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class ModifierHandler : MonoBehaviour
{
    public RobotStatus RoboStats;
    void Start()
    {
        RoboStats = FindObjectOfType<RobotStatus>(); 

    }
    public void SetupMod(GameObject Modifier)
    {
        Sprite ModImage = Modifier.GetComponent<SpriteRenderer>().sprite;
        if (ModImage.name == "Modifiers_5")
        {
            Debug.Log("Setting up " + Modifier.name);
            Modifier.AddComponent<Weapon>();
            Weapon ModWeapon = Modifier.GetComponent<Weapon>();
            if (ModWeapon.Level > 1) //If we're combining two of the same weapon
            {
                ModWeapon.Level += Modifier.GetComponent<Weapon>().Level;
            }
            else //Otherwise set up the new weapon slot
            {
                Debug.Log("Setting New Weapon Up");
                ModWeapon.Level = 1;
                Transform spawnPoint = RoboStats.WeaponSlotSetup();
                ModWeapon.spawnPoint = spawnPoint;
                ModWeapon.spawnPoint.position = spawnPoint.position;
                Modifier.transform.GetChild(0).transform.position = spawnPoint.position;
            }
        }

    }
}
