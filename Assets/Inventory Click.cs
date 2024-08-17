using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClick : MonoBehaviour {

    public Camera cam;
    public int slotID;
    public TilePlacer tilePlacer;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Item")) {
                Debug.Log("CLICKED " + hit.collider.name);
                tilePlacer.inventory_Item = slotID;
            }
        }
    }
}