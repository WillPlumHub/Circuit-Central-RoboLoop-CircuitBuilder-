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
    private bool clicked = false;

    [Header("Script References")]
    public Inventory inventory;
    public ItemDrop item;
    AudioManager audioManager;
    #endregion

    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        randomNumber = Random.Range(1, 5);
        startPos = transform.position;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        item = GetComponent<ItemDrop>();
        SpriteLayerSwap();
    }

    void Update() {
        if (clicked == false) {
            movement();
        }
    }

    void SpriteLayerSwap() {
        int rand = Random.Range(4, 9);
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = rand;
    }

    void movement() {
        float x = transform.position.x + Time.deltaTime * moveSpeed;
        float y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude * randomNumber;
        this.transform.position = new Vector3(x, y, startPos.z);
        audioManager.PlaySFX(audioManager.BalloonMove);
    }

    private void OnMouseDown() {
        this.gameObject.GetComponent<Animator>().SetBool("ClickedBalloon", true);
        item.ItemDrops();
        clicked = true;
    }

    private void DestroyBalloon() {
        audioManager.PlaySFX(audioManager.BalloonPop);
        Destroy(gameObject);
    }
}