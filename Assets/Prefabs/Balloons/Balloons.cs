using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Balloons : MonoBehaviour {

    #region Variables
    [Header("Randomizer")]
    public int randomNumber;
    public int lastNumber;
    public int maxAttempts = 10;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float amplitude = 1f;
    public float frequency = 1f;
    private Vector3 startPos;

    [Header("Script References")]
    public Inventory inventory;
    public ItemDrop item;
    #endregion
    
    void Start() {
        randomNumber = Random.Range(0, 5);
        startPos = transform.position;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        item = GetComponent<ItemDrop>();
    }

    void Update() {
        movement();
    }

    void movement() {
        float x = transform.position.x + Time.deltaTime * moveSpeed;
        float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude * randomNumber;
        this.transform.position = new Vector3(x, y, startPos.z);
    }

    private void OnMouseDown() {
        item.ItemDrops();
        //play pop anim
        Destroy(gameObject);
    }
}