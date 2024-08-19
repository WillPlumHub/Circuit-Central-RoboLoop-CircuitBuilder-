using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ceaseFire : MonoBehaviour {

    public bool inBetween;
    public Weapon[] weapons;

    Weapon[] GetAllWeaponsInScene() {

        List<Weapon> objectsInScene = new List<Weapon>();

        foreach (Weapon go in Resources.FindObjectsOfTypeAll<Weapon>()) {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)) {
                objectsInScene.Add(go);
            }
        }
        return objectsInScene.ToArray();
    }

    void Update() {
        if (inBetween) {
            //disable weapons
            weapons = GetAllWeaponsInScene();
            for (int i = 0; i <= weapons.Length-1; i++) {
                weapons[i].GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        else {
            weapons = GetAllWeaponsInScene();
            for (int i = 0; i <= weapons.Length-1; i++) {
                weapons[i].GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
}
