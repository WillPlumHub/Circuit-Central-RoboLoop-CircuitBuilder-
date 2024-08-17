using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Balloons : MonoBehaviour {

    public int randomNumber;
    public int lastNumber;
    public int maxAttempts = 10;

    public float moveSpeed = 2f;
    public float amplitude = 1f;
    public float frequency = 1f;

    private Vector3 startPos;

    public Inventory inventory;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        //movement
        float x = startPos.x + Time.time * moveSpeed;
        float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude; 
        transform.position = new Vector3(x, y, startPos.z);
    }

    int NewRandomNumber() {
        for (int i = 0; randomNumber == lastNumber && i < maxAttempts; i++) {
            randomNumber = Random.Range(0, inventory.inventory.Count + inventory.modifiers.Count);
        }
        lastNumber = randomNumber;
        Debug.Log("Number: " + lastNumber);
        return lastNumber;
    }

    void DropItem(int index) {
        if (index < inventory.inventory.Count) {
            inventory.inventory[index].amount++;
            Debug.Log("Item dropped: " + inventory.inventory[index].name);
        } else {
            index -= inventory.inventory.Count;
            inventory.modifiers[index].amount++;
            Debug.Log("Mod dropped: " + index + inventory.modifiers[index].name);
        }
    }

    private void OnMouseDown() {
        DropItem(NewRandomNumber()); //drop item based on last randomly generated number
        //play pop anim
        //Destroy(gameObject);
    }
}