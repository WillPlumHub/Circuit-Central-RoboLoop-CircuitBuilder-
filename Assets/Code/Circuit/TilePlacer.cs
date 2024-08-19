using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour {

    #region Variables
    [Header("Inventory Slot Being Referenced")]
    public int inventory_Item = 1;
    public ItemInstance currItem;
    public Modifier currMod;
    
    [Header("Tile vs Mod Switch")]
    public bool usingTiles;

    [Header("Click Detection")]
    public Vector2 clickPos; 
    public Vector2 clickGridPos;

    [Header("Script References")]
    public Tilemap Tilemap; 
    public Inventory inventory;
    public pauseMenu pauseMenu;
    public ModifierHandler modHandler;
    AudioManager audioManager;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        modHandler = FindObjectOfType<ModifierHandler>();
        inventory = FindObjectOfType<Inventory>();
    }

    void Update() {
        if (!pauseMenu.isPaused) {
            HandleMouseClick();
            HandleKeyboardInput();
            InventorySelect();
        }
    }

    private void HandleMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = Tilemap.WorldToCell(worldPos);

            if (usingTiles) {
                PlaceTile(gridPos);
            }
            else {
                PlaceModifier(gridPos);
            }
        }
    }

    private void PlaceTile(Vector3Int gridPos) {
        if (Tilemap.HasTile(gridPos) && currItem.amount > 0 && Tilemap.GetTile(gridPos).name != currItem.name) {
                currItem.amount--;
            inventory.inventory[inventory_Item] = currItem;
            Tilemap.SetTile(gridPos, currItem.tile);
        }
    }

    private void PlaceModifier(Vector3Int gridPos) {
        if (Tilemap.HasTile(gridPos) && currMod.amount > 0 && Tilemap.GetTile(gridPos).name != currMod.name) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.transform.gameObject.GetComponent<BoxCollider2D>() || hit.transform.gameObject.GetComponent<BoxCollider2D>())
                {
                    string strippedRay = hit.transform.gameObject.name.Replace("(Clone)", "");
                    string strippedMod = currMod.modifier.name.Replace("(Clone)", "");
                    Debug.Log(" status: " + strippedRay + " " + strippedMod);
                    if (strippedRay == currMod.modifier.name)
                    {
                        modHandler.LevelUpModifier(currMod.modifier);
                        return;
                    }
                    else
                    {
                        Debug.Log("Failed to place; Different mod already present in location");
                        return;
                    }
                }
            }
            currMod.amount--;

                inventory.modifiers[inventory_Item - inventory.inventory.Count] = currMod;
                GameObject tileOverlay = Instantiate(currMod.modifier, new Vector3(gridPos.x + .5f, gridPos.y + .5f, (float)gridPos.z), Quaternion.identity);
                tileOverlay.GetComponent<SpriteRenderer>().sprite = currMod.overlaySprite;
                tileOverlay.GetComponent<SpriteRenderer>().sortingOrder = 3;
                modHandler.SetupMod(tileOverlay);
                Debug.Log("Functional");
            
        }
    }

    private void HandleKeyboardInput() {
        if (Input.GetKey("1")) inventory_Item = 11;
        else if (Input.GetKey("2")) inventory_Item = 5;
        else if (Input.GetKey("3")) inventory_Item = 6;
        else if (Input.GetKey("4")) inventory_Item = 7;

        if (inventory_Item < 0) inventory_Item = 0;
        else if (inventory_Item >= inventory.inventory.Count + inventory.modifiers.Count) inventory_Item = inventory.inventory.Count + inventory.modifiers.Count - 1;
    }

    public void InventorySelect() {
        //slect itemID = 1 from inventory for now, register user selection later
        usingTiles = inventory_Item < inventory.inventory.Count;
        if (usingTiles) {
            currItem = inventory.inventory[inventory_Item];
        } else {
            currMod = inventory.modifiers[inventory_Item - inventory.inventory.Count];
        }
        
    }
}