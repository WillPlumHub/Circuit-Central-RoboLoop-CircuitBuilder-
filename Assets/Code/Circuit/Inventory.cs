using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

/*[System.Serializable]
public struct InventorySlots {
    public string Name;
    public int SlotID;
    public TileBase Tile;
    public TileBase Modifier;
    public int Amount;
    
    public InventorySlots(string Name, int SlotID, TileBase Tile, TileBase Modifier, int Amount) : this() {
        this.Name = Name;
        this.SlotID = SlotID;
        this.Tile = Tile;
        this.Tile = Modifier;
        this.Amount = Amount;
    }
}*/

public class Inventory : MonoBehaviour {

    public List<ItemInstance> inventory = new List<ItemInstance>();
    
    private void Start() {
        /*
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
        inventory.Add(corner);*/

        for (int i = 0; i < inventory.Count; i++) {
            ItemInstance tempItem = inventory[i];
            tempItem.slotID = i + 1;
            inventory[i] = tempItem;
        }
    }
}
