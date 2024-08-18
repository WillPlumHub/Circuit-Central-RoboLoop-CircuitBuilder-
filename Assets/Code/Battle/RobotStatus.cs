using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class RobotStatus : MonoBehaviour
{
    public int WeaponSlots;
    public int UsedSlots = 0;
    public int RoboHealth;

    public GameObject[] SlotLocations = new GameObject[4];
    public GameObject overLoadSlot;

    public Transform WeaponSlotSetup()
    {
        if(UsedSlots < 4)
        {
            Transform weaponLocation = SlotLocations[UsedSlots].transform;
            UsedSlots++;
            return weaponLocation;
        }
        else
        {
            Debug.Log("Warning: All slots already assigned");
            Transform weaponLocation = overLoadSlot.transform;
            return weaponLocation;
        }

    }
}
