using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour {

    public int inventory_Item = 1;
    public ItemInstance currItem;
    public Vector2 clickPos; 
    public Vector2 clickGridPos;
    public Tilemap Tilemap;

    public Inventory inventory;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3Int gridPos = Tilemap.WorldToCell(worldPos);

            if (Tilemap.HasTile(gridPos) && currItem.amount > 0
                
                && Tilemap.GetTile(gridPos).name != inventory.inventory[inventory_Item].name) {

                //Debug.Log(Tilemap.GetTile(gridPos).name != inventory.inventory[inventory_Item].name);
                //Debug.Log("H" + Tilemap.GetTile(gridPos).name + "H     H" + inventory.inventory[inventory_Item].tile.name + "H");

                ItemInstance tempItem = inventory.inventory[inventory_Item];
                tempItem.amount--;
                inventory.inventory[inventory_Item] = tempItem;
                
                Tilemap.SetTile(gridPos, inventory.inventory[inventory_Item].tile);
                
            }
        }

        //Keyboard shortcuts
        if (Input.GetKey("1")) {
            inventory_Item = 0;
        }
        if (Input.GetKey("2")) {
            inventory_Item = 1;
        }
        if (Input.GetKey("3")) {
            inventory_Item = 2;
        }

        InventorySelect();
    }

    public void InventorySelect() {
        //slect itemID = 1 from inventory for now, register user selection later
        if (inventory_Item >= inventory.inventory.Count) {
            Debug.Log("Fuck You");
            inventory_Item--;
        }
        else if (inventory_Item < 0) {
            Debug.Log("Fuck You");
            inventory_Item++;
        }
        else {
            currItem = inventory.inventory[inventory_Item];
        }
        
    }
}