using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public struct InventorySlots {
    public string name;
    public int slotID;
    public TileBase tile;
    public int amount;
}
public class Inventory : MonoBehaviour {

    public TileBase Tile;
    public InventorySlots vert;
    public InventorySlots hori;
    public InventorySlots corner;
    
    List<InventorySlots> inventory = new List<InventorySlots>();
    
    private void Start() {
        inventory.Add(vert);
        inventory.Add(hori);
        inventory.Add(corner);

        vert.name = "Straight Vertical";
        vert.slotID = 1;
        vert.tile = Tile;
        vert.amount = 2;
        hori.name = "Straight Horizontal";
        hori.slotID = 2;
        hori.tile = Tile;
        hori.amount = 2;
        corner.name = "Corner";
        corner.slotID = 1;
        corner.tile = Tile;
        corner.amount = 2;
    }

}
