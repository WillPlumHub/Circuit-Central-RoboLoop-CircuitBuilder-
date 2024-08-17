using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]

public class ItemInstance : ScriptableObject {
    public string itemName;
    public int slotID;
    public TileBase tile;
    public TileBase modifier;
    public int amount;
}
