using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "GameObject/Item")]
public class Item : ScriptableObject {
    public TileBase tile;
    public Sprite image;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(x:5, y:4);
 }

public enum ItemType
{
    buildingBlock,
    Tool
}

public enum ActionType
{
    Dig,
    Mine
}
