using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]

public class Modifier : ScriptableObject {
    public string itemName;
    public int slotID;
    public Sprite overlaySprite;
    public GameObject modifier;
    public int amount;
}
