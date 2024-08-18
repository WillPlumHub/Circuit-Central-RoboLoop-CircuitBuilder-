using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMod : MonoBehaviour {

    #region Variables
    [Header("Basics")]
    public int slotID;
    
    [Header("References")]
    public TilePlacer tilePlacer;
    public Modifier modifier;

    [Header("Component References")]
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;
    #endregion

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
    }

    void Update() {
        if (gameObject.GetComponent<Renderer>().enabled == false && modifier.amount > 0) {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (modifier.amount <= 0) {
            spriteRenderer.color = new Color(0, 1, 0, 1);
        }
        else {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseDown() {
        tilePlacer.inventory_Item = slotID;
        Debug.Log("YES");
    }
}
