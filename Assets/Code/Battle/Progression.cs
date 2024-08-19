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
    public float moveSpeed = 1;

    [Header("Battle Reset")]
    public float timeToResetBattle;
    public SparkMove sparkMove;
    public bool resetEnemy = false;
    
    [Header("Timer")]
    public float timer = 0;
    public bool active;
    #endregion

    void Update() {
        runTime();
        enemyProgression();

        if (resetEnemy) {
            enemyReload();
            
        }
    }

    public void runTime() {
        if (active) {
            timer += Time.deltaTime;
        }
    }

    public void enemyProgression() {
        if (!IsListFullOfNull()) { //If list is full of nulls a.k.a all enemies have died
            if (encounters[currEnemyRef].GetComponent<Enemy>().health <= 0) { //If cur enemy dies
                Debug.Log("Died");

                StartCoroutine(resetBattle());

                difficulty += 0.4f;

                if (currEnemyRef != encounters.Count - 1) { //and its not the last one
                    Debug.Log("Not the last");
                    currEnemyRef++;
                }
                else { //If it is the last in the list
                    Debug.Log("End of list");
                }
            }
        }
        else { //all enemies have died
            Debug.Log("All enemies have died");
        }
    }

    public void enemyReload() {
        if (Vector3.Distance(encounters[currEnemyRef].transform.position, enemyPlace) > 0.01f) {
            encounters[currEnemyRef].transform.position = Vector3.MoveTowards(encounters[currEnemyRef].transform.position, enemyPlace, moveSpeed * Time.deltaTime);
        } else { resetEnemy = false; }
    }

    public bool IsListFullOfNull() {
        return encounters != null && encounters.All(item => item == null);
    }

    IEnumerator resetBattle() {
        sparkMove.boostMult = 10;

        yield return new WaitForSeconds(timeToResetBattle);
        Debug.Log("THT");

        resetEnemy = true;
        Debug.Log("HTH");
    }
}