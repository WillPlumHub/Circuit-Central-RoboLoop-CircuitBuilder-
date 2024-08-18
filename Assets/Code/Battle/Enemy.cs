using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region Variables
    [Header("Health")]
    public float health = 1; 
    public string element;

    [Header("Drop List")]
    public List<Modifier> drops = new List<Modifier>();

    [Header("Drop Spawns")]
    public List<Transform> dropSpawns = new List<Transform>();
    
    [Header("Attacking")]
    public bool hostile; 
    public float firingRate = 1;
    public GameObject projectile;
    public Transform spawnPoint;
    
    [Header("Script References")]
    public Progression prog;
    public Inventory inventory;
    #endregion

    void Start() {
        if (hostile) {
            StartCoroutine(attacking());
        }
    }

    void Update() {
        if (health <= 0) {
            //send any flags
            ItemDrop();
            Destroy(gameObject);
        }
    }

    List<Modifier> ItemDrop() {
        int randomNumber = Random.Range(0, 101);
        Debug.Log("Numb" + randomNumber);
        List<Modifier> possibleItems = new List<Modifier>();
        foreach(Modifier item in drops) {
            if (randomNumber <= item.dropRate) {
                possibleItems.Add(item);
                Debug.Log("Item: " + item);
            }
        }
        if (possibleItems.Count > 0) {
            CollectDrops(possibleItems);
            SpawnDrops(possibleItems);
            return possibleItems;
        } else {
            Debug.Log("No items");
            return null;
        }
    }

    void CollectDrops(List<Modifier> possibleItems) {
        foreach(Modifier item in possibleItems) {

            Debug.Log("SlotID: " + item.slotID + " Tile Array Max: " + inventory.inventory.Count + " Mod Array Count: " + inventory.modifiers.Count + " Modded slotID: " + (item.slotID - inventory.inventory.Count-1));

            if (item.slotID < inventory.inventory.Count) {
                Debug.Log("Old amount: " + inventory.inventory[item.slotID].amount + " of slotID: " + item.slotID); 
                inventory.inventory[item.slotID].amount++;
                Debug.Log("New amount: " + inventory.inventory[item.slotID].amount);
            } else {
                Debug.Log("Old amount: " + inventory.modifiers[item.slotID - inventory.inventory.Count - 1].amount + " of slotID: " + item.slotID);
                inventory.modifiers[item.slotID - inventory.inventory.Count-1].amount++;
                Debug.Log("New amount: " + inventory.modifiers[item.slotID - inventory.inventory.Count - 1].amount);
            }
        }
    }

    void SpawnDrops(List<Modifier> possibleItems) {
        if (possibleItems != null && possibleItems.Count > 0) {
            for (int i = 0; i < Mathf.Min(dropSpawns.Count, possibleItems.Count); i++) {
                // Assuming the Modifier should be a GameObject to instantiate
                GameObject lootDrop = Instantiate(possibleItems[i].modifier, dropSpawns[i].position, Quaternion.identity);
                SpriteRenderer spriteRenderer = lootDrop.GetComponent<SpriteRenderer>();

                // Ensure lootDrop has a SpriteRenderer component
                if (spriteRenderer != null) {
                    spriteRenderer.sprite = possibleItems[i].overlaySprite;
                }
                else {
                    Debug.LogWarning("LootDrop GameObject has no SpriteRenderer");
                }
            }
        }
        else {
            Debug.LogWarning("No possible items to spawn or no spawn points available.");
        }
    }




    IEnumerator attacking() {
        while (hostile && health > 0 && spawnPoint != null) {
            Instantiate(projectile, spawnPoint.position, projectile.transform.rotation);
            yield return new WaitForSeconds(firingRate / prog.difficulty);
        }
    }
}
