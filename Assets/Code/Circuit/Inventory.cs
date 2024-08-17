using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

[System.Serializable]
public struct InventorySlots {
    public string name;
    public int slotID;
    public TileBase tile;
    public int amount;
    
    public InventorySlots(string name, int slotID, TileBase tile, int amount) {
        this.name = name;
        this.slotID = slotID;
        this.tile = tile;
        this.amount = amount;
    }
}

public class Inventory : MonoBehaviour {

    public InventorySlots vert;
    public InventorySlots hori;
    public InventorySlots corner;
    
    public List<InventorySlots> inventory = new List<InventorySlots>();
    
    private void Start() {

        vert.name = "Straight_Vertical";
        //vert.slotID = 1;
        vert.tile = AssetDatabase.LoadAssetAtPath<TileBase>("Assets/Prefabs/Tiles/Circoncept_2.asset");
        vert.amount = 2;
        hori.name = "Straight_Horizontal";
        //hori.slotID = 2;
        hori.tile = AssetDatabase.LoadAssetAtPath<TileBase>("Assets/Prefabs/Tiles/Circoncept_0.asset");
        hori.amount = 2;
        corner.name = "Corner";
        //corner.slotID = 3;
        corner.tile = AssetDatabase.LoadAssetAtPath<TileBase>("Assets/Prefabs/Tiles/Circoncept_3.asset");
        corner.amount = 2;

        inventory.Add(vert);
        inventory.Add(hori);
        inventory.Add(corner);

        for (int i = 0; i < inventory.Count; i++) {
            InventorySlots tempItem = inventory[i];
            tempItem.slotID = i + 1;
            inventory[i] = tempItem;
        }
    }
}
