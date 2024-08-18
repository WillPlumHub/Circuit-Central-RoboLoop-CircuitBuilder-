using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InventoryClick : MonoBehaviour {

    public int slotID;

    public TilePlacer tilePlacer;
    public ItemInstance itemInstance;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
    }
    void Update() {
        if (gameObject.GetComponent<Renderer>().enabled == false && itemInstance.amount > 0) {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        } else if (itemInstance.amount <= 0) {
            spriteRenderer.color = new Color(0, 1, 0, 1);
        } else {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseDown() {
        tilePlacer.inventory_Item = slotID;
        Debug.Log("YES");
    }
}