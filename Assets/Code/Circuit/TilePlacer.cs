using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour {

    public int inventory_Item = 1;
    public ItemInstance currItem;
    public Modifier currMod;

    public bool usingTiles;

    public Vector2 clickPos; 
    public Vector2 clickGridPos;
    public Tilemap Tilemap;

    public Inventory inventory;

    

    void Update() {
        HandleMouseClick();
        HandleKeyboardInput();
        InventorySelect();
    }

    private void HandleMouseClick() {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = Tilemap.WorldToCell(worldPos);

            if (usingTiles) {
                PlaceTile(gridPos);
            }
            else {
                PlaceModifier(gridPos);
            }
        }
    }

    private void PlaceTile(Vector3Int gridPos) {
        if (Tilemap.HasTile(gridPos) && currItem.amount > 0 && Tilemap.GetTile(gridPos).name != currItem.name) {
                currItem.amount--;
            inventory.inventory[inventory_Item] = currItem;
            Tilemap.SetTile(gridPos, currItem.tile);
        }
    }

    private void PlaceModifier(Vector3Int gridPos) {
        if (Tilemap.HasTile(gridPos) && currMod.amount > 0 && Tilemap.GetTile(gridPos).name != currMod.name) {
            currMod.amount--;
            inventory.modifiers[inventory_Item - inventory.inventory.Count] = currMod;
            GameObject tileOverlay = Instantiate(currMod.modifier, new Vector3(gridPos.x + .5f, gridPos.y + .5f, (float)gridPos.z), Quaternion.identity);
            tileOverlay.GetComponent<SpriteRenderer>().sprite = currMod.overlaySprite;
            tileOverlay.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Debug.Log("Functional");
        }
    }

    private void HandleKeyboardInput() {
        if (Input.GetKey("1")) inventory_Item = 0;
        else if (Input.GetKey("2")) inventory_Item = 1;
        else if (Input.GetKey("3")) inventory_Item = 2;
        else if (Input.GetKey("4")) inventory_Item = 3;

        if (inventory_Item < 0) inventory_Item = 0;
        else if (inventory_Item >= inventory.inventory.Count + inventory.modifiers.Count) inventory_Item = inventory.inventory.Count + inventory.modifiers.Count - 1;
    }

    public void InventorySelect() {
        //slect itemID = 1 from inventory for now, register user selection later
        usingTiles = inventory_Item < inventory.inventory.Count;
        if (usingTiles) {
            currItem = inventory.inventory[inventory_Item];
        } else {
            currMod = inventory.modifiers[inventory_Item - inventory.inventory.Count];
        }
        
    }
}