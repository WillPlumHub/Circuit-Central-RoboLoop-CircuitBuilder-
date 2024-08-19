using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ModifierHandler : MonoBehaviour
{
    public RobotStatus RoboStats;
    public Tilemap tilemap;
    public int DamageBoost = 0;
    void Start()
    {
        RoboStats = FindObjectOfType<RobotStatus>();
        tilemap = GameObject.Find("Temp Tilemap").GetComponent<Tilemap>();

    }
    public void SetupMod(GameObject Modifier)
    {
        Sprite ModImage = Modifier.GetComponent<SpriteRenderer>().sprite;
        if (ModImage.name == "Modifiers_5")
        {
            Debug.Log("Setting up " + Modifier.name);
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
        /*if (ModImage.name == "Modifiers_5")
        {
            Debug.Log("Setting up " + Modifier.name);
            Weapon ModWeapon = Modifier.GetComponent<Weapon>();
            if(ModWeapon.Level > 1)
            {
                ModWeapon.Level +=
            }
            else
            {

            }
        }*/
    }

    public bool TilePresent(Vector3Int location)
    {
        Debug.Log("Checking");
        if (!tilemap.HasTile(location))
        {
            return false;
        }
        return true;
    }
}
