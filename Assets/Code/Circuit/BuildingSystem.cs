using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour {

    [SerializeField] private Item item;
    [SerializeField] private TileBase highlightTile;
    [SerializeField] private Tilemap mainTileMap;
    [SerializeField] private Tilemap tempTileMap;

    private Vector3Int highlightedPos;
    private bool highlighted;

    private void Update()
    {
        if (item != null)
        {
            HighlightTile(item);
        }
    }

    private Vector3Int GetMouseOnGridPos() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = mainTileMap.WorldToCell(mousePos);
        mouseCellPos.z = 0;
        return mouseCellPos;
    }

    private void HighlightTile (Item currentItem) {
        Vector3Int mouseGridPos = GetMouseOnGridPos();
        if (highlightedPos != mouseGridPos) {
            tempTileMap.SetTile(highlightedPos, tile: null);
            TileBase tile = mainTileMap.GetTile(mouseGridPos);
            if (tile)
            {
                tempTileMap.SetTile(mouseGridPos, highlightTile);
                highlightedPos = mouseGridPos;
                highlighted = true;
            } else
            {
                highlighted = false;
            }
        }
    }
}
