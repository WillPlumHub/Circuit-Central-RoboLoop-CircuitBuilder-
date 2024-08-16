using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour {

    public GameObject currTile;
    public Vector2 clickPos; 
    public Vector2 clickGridPos;
    public Tilemap Tilemap;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector3Int gridPos = Tilemap.WorldToCell(worldPos);
            
            if (!Tilemap.HasTile(gridPos)) {
                Debug.Log(worldPos + " " + gridPos);
            }
        }
    }
}