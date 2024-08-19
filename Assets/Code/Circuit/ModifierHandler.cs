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
        Debug.Log("Modifier sprite: " + ModImage.name);
        if (ModImage.name == "Modifiers_5")
        {
            Debug.Log("Setting up " + Modifier.name);
            Weapon ModWeapon = Modifier.GetComponent<Weapon>();

            Debug.Log("Setting New Weapon Up");
            ModWeapon.Level = 1;
            Transform spawnPoint = RoboStats.WeaponSlotSetup();
            ModWeapon.spawnPoint = spawnPoint;
            ModWeapon.spawnPoint.position = spawnPoint.position;
            Modifier.transform.GetChild(0).transform.position = spawnPoint.position;
            
        }

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

    public void LevelUpModifier(GameObject toLevel)
    {
        Debug.Log("Leveling" + toLevel.name);
        if (toLevel.GetComponent<SpriteRenderer>().sprite.name == "Modifiers_5")
        {
            toLevel.GetComponent<Weapon>().Level++;
        }
        else
        {

            string recipient = toLevel.name.Replace("(Clone)", "");
            Debug.Log("Recipient: " + recipient);
            if (recipient == "Clover"){ toLevel.GetComponent<CloverMechanic>().level++; Debug.Log("working"); }
            if (recipient == "Heart") { toLevel.GetComponent<HeartMechanic>().level++; }
            if (recipient == "Soup") { toLevel.GetComponent<SoupMechanic>().level++; }
            if (recipient == "DamageBoost") { toLevel.GetComponent<DamageBoostMechanic>().level++; }
            if (recipient == "DamageMult") { toLevel.GetComponent<DamageMultMechanic>().level++; }
            if (recipient == "SpeedBoost") { toLevel.GetComponent<SpeedBoostMechanic>().level++; }

            toLevel.transform.Find("LevelUpAnim").GetComponent<SpriteRenderer>().enabled = true;
            toLevel.transform.Find("LevelUpAnim").GetComponent<Animator>().SetTrigger("LevelUp");
            StartCoroutine(LevelAnimDeactivate(toLevel));
        }
    }

    public IEnumerator LevelAnimDeactivate(GameObject toLevel)
    {
        yield return new WaitForSeconds(0.7f);
        toLevel.transform.Find("LevelUpAnim").GetComponent<SpriteRenderer>().enabled = false;

    }
}
