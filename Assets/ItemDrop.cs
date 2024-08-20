using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {

    #region Variables
    public GameObject lootDrop;

    [Header("Drop List")]
    public List<Modifier> drops = new List<Modifier>();

    [Header("Drop Spawns")]
    public List<Transform> dropSpawns = new List<Transform>();

    [Header("Drop Modifier")]
    public float dropBoost = 1;

    [Header("Script References")]
    public Inventory inventory;
    AudioManager audioManager;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public List<Modifier> ItemDrops() {
        int randomNumber = Random.Range(0, 101);
        Debug.Log("Numb" + randomNumber);
        List<Modifier> possibleItems = new List<Modifier>();
        foreach (Modifier item in drops) {
            if (randomNumber / dropBoost <= item.dropRate) {
                possibleItems.Add(item);
                Debug.Log("Item: " + item);
            }
        }
        if (possibleItems.Count > 0) {
            CollectDrops(possibleItems);
            SpawnDrops(possibleItems);
            dropBoost = 1;
            return possibleItems;
        }
        else {
            Debug.Log("No items");
            return null;
        }
    }

    void CollectDrops(List<Modifier> possibleItems) {
        foreach (Modifier item in possibleItems) {

            //Debug.Log("SlotID: " + item.slotID + " Tile Array Max: " + inventory.inventory.Count + " Mod Array Count: " + inventory.modifiers.Count + " Modded slotID: " + (item.slotID - inventory.inventory.Count - 1));

            if (item.slotID < inventory.inventory.Count) {
               // Debug.Log("Old amount: " + inventory.inventory[item.slotID].amount + " of slotID: " + item.slotID);
                inventory.inventory[item.slotID].amount++;
                //Debug.Log("New amount: " + inventory.inventory[item.slotID].amount);
            }
            else {
                //Debug.Log("Old amount: " + inventory.modifiers[item.slotID - inventory.inventory.Count - 1].amount + " of slotID: " + item.slotID);
                inventory.modifiers[item.slotID - inventory.inventory.Count - 1].amount++;
                //Debug.Log("New amount: " + inventory.modifiers[item.slotID - inventory.inventory.Count - 1].amount);
            }
        }
    }

    void SpawnDrops(List<Modifier> possibleItems) {
        if (possibleItems != null && possibleItems.Count > 0) {
            if (dropSpawns.Count != 0) {
                for (int i = 0; i < Mathf.Min(dropSpawns.Count, possibleItems.Count); i++) {
                    Debug.Log(possibleItems[i].modifier);
                    lootDrop = Instantiate(possibleItems[i].modifier, dropSpawns[i].position, Quaternion.identity);
                    lootDrop.AddComponent<dropCollect>();
                    lootDrop.AddComponent<Rigidbody2D>();
                    lootDrop.transform.GetChild(0).gameObject.AddComponent<dropCollect>();
                    lootDrop.transform.GetChild(0).gameObject.AddComponent<Rigidbody2D>();
                    SpriteRenderer spriteRenderer = lootDrop.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null) {
                        spriteRenderer.sprite = possibleItems[i].overlaySprite;
                    }
                    else {
                        Debug.LogWarning("LootDrop GameObject has no SpriteRenderer");
                    }
                }
            }
            else {
                for (int i = 0; i < possibleItems.Count; i++) {
                    lootDrop = Instantiate(possibleItems[i].modifier, transform.position, Quaternion.identity);
                    lootDrop.AddComponent<dropCollect>();
                    lootDrop.AddComponent<Rigidbody2D>();
                    lootDrop.transform.GetChild(0).gameObject.AddComponent<dropCollect>();
                    lootDrop.transform.GetChild(0).gameObject.AddComponent<Rigidbody2D>();
                    SpriteRenderer spriteRenderer = lootDrop.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null) {
                        spriteRenderer.enabled = false;
                    }
                    else {
                        Debug.LogWarning("LootDrop GameObject has no SpriteRenderer");
                    }
                }
            }
        }
        else {
            Debug.LogWarning("No possible items to spawn or no spawn points available.");
        }
    }


}