using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Progression : MonoBehaviour {

    #region Variables
    [Header("Run Variables")]
    public float difficulty = 1;

    [Header("Enemy List")]
    public List<GameObject> encounters = new List<GameObject>();
    public int currEnemyRef = 0;
    public Vector3 enemyPlace;

    [Header("Timer")]
    public float timer = 0;
    public bool active;
    #endregion

    void Start() {
        
    }

    void Update() {
        if (active) {
            timer += Time.deltaTime;
        }

        if (!IsListFullOfNull()) { //If list is full of nulls a.k.a all enemies have died
            if (encounters[currEnemyRef].GetComponent<Enemy>().health <= 0) { //If cur enemy dies
                Debug.Log("Died");
                if (currEnemyRef != encounters.Count - 1) { //and its not the last one
                    Debug.Log("Not the last");
                    currEnemyRef++;
                    encounters[currEnemyRef].gameObject.transform.position = enemyPlace;
                } else { //If it is the last in the list
                    Debug.Log("End of list");
                }
            }
        } else { //all enemies have died
            Debug.Log("All enemies have died");
        }
    }

    public bool IsListFullOfNull() {
        return encounters != null && encounters.All(item => item == null);
    }
}