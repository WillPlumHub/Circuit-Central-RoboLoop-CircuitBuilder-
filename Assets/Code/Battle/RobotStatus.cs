using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class RobotStatus : MonoBehaviour {

    #region Variables
    [Header("Weapon Data")]
    public int WeaponSlots;
    public int UsedSlots = 0;

    [Header("Weapon Slots")]
    public GameObject overLoadSlot; 
    public GameObject[] SlotLocations = new GameObject[4];

    [Header("Robo Stats")]
    public int RoboHealth = 10;
    #endregion

    void Update() {
        if (RoboHealth <= 0) {
            Debug.Log("GAME OVER BITCHES");
            //send part of that damage to the weapons
        }
    }

    public Transform WeaponSlotSetup() {
        if(UsedSlots < 4) {
            Transform weaponLocation = SlotLocations[UsedSlots].transform;
            UsedSlots++;
            return weaponLocation;
        }
        else {
            Debug.Log("Warning: All slots already assigned");
            Transform weaponLocation = overLoadSlot.transform;
            return weaponLocation;
        }
    }
}