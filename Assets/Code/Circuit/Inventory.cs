using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Inventory : MonoBehaviour {

    public List<ItemInstance> inventory = new List<ItemInstance>();
    public List<Modifier> modifiers = new List<Modifier>();
    
    private void Start() {

        for (int i = 0; i < inventory.Count; i++) {
            ItemInstance tempItem = inventory[i];
            tempItem.slotID = i + 1;
            inventory[i] = tempItem;
        }
    }
}
