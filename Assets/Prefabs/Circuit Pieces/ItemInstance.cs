using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]

public class ItemInstance : ScriptableObject
{
    // Start is called before the first frame update
    public string ItemName;
    public int slotID;
    public TileBase tile;
    public TileBase modifier;
    public int amount;
}
