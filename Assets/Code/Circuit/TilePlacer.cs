using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour {

    public TileBase currTile;
    public Vector2 clickPos; 
    public Vector2 clickGridPos;
    public Tilemap Tilemap;

    public Inventory inventory;
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3Int gridPos = Tilemap.WorldToCell(worldPos);
            
            if (Tilemap.HasTile(gridPos)) {
                Debug.Log(worldPos + " " + gridPos);
                Tilemap.SetTile(gridPos, currTile);
                //Tilemap.InsertCells(gridPos, new Vector3Int(1,1,1));
            }
        }
    }

    public void InventorySelect() {
        //slect itemID = 1 from inventory for now, register user selection later
        inventory.vert.
    }
}