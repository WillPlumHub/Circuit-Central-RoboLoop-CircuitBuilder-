using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InventoryMod : MonoBehaviour {

    #region Variables
    [Header("Basics")]
    public int slotID;
    
    [Header("References")]
    public TilePlacer tilePlacer;
    public Inventory inventory;
    public Modifier modifier;

    [Header("Component References")]
    public SpriteRenderer spriteRenderer;
    BoxCollider2D boxCol;
    public TMP_Text Text;
    public TMP_Text Desc;
    #endregion

    private void Start() {
        tilePlacer = FindObjectOfType<TilePlacer>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        //spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //GetComponent<SpriteRenderer>();
        //Debug.Log(spriteRenderer);
        spriteRenderer.enabled = false;
        Desc.enabled = false;
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
    }

    void Update() {
        if (spriteRenderer.enabled == false && modifier.amount > 0) {
            Desc.enabled = true;
            spriteRenderer.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        amountUpdate();

        if (tilePlacer.inventory_Item == slotID) {
            //Debug.Log("CLICKED");
            gameObject.GetComponent<Animator>().SetTrigger("Select");
        } else {
            gameObject.GetComponent<Animator>().SetTrigger("Unselect");
        }

    }

    void amountUpdate() {
        Text.text = inventory.modifiers[slotID - inventory.inventory.Count].amount.ToString();
    }

    private void OnMouseDown() {
        tilePlacer.inventory_Item = slotID;
        Debug.Log("YES");
    }
}
