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
    public List<Transform> progressionPositions = new List<Transform>();
    public List<GameObject> enemyTypes = new List<GameObject>();
    public int currEnemyRef = 0;
    public Vector3 enemyPlace;
    public Vector3 offscreenEnemies;
    public float moveSpeed = 1;
    private GameObject newLastEnemy;


    [Header("Battle Reset")]
    public float timeToResetBattle;
    public SparkMove sparkMove;
    public bool resetEnemy = false;
    public ceaseFire ceaseFire;
    public bool isEnemyDead = false;
    public RobotStatus roboStats;
    
    [Header("Timer")]
    public float timer = 0;
    public bool active;
    #endregion

    void Start()
    {
        sparkMove = FindObjectOfType<SparkMove>();
        ceaseFire = FindObjectOfType<ceaseFire>();
        roboStats = FindObjectOfType<RobotStatus>();
    }
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
                isEnemyDead = true;
                StartCoroutine(resetBattle());

                difficulty += 0.2f;
                Debug.Log("Encounters length " + encounters.Count);
                for (int i = 0; i < encounters.Count - 1; i++) //shuffle list forwards
                {
                    Debug.Log(" i = " + i);
                    encounters[i] = encounters[i + 1];
                }
                GameObject newLastEnemy = summonEnemy();
                encounters[4] = newLastEnemy;

                /*
                                if (currEnemyRef != encounters.Count - 1) { //and its not the last one
                                    Debug.Log("Not the last");
                                    currEnemyRef++;
                                }
                                else { //If it is the last in the list
                                    Debug.Log("End of list");
                                }*/
            }
        }
        else { //all enemies have died
            Debug.Log("All enemies have died");
        }
    }

    public void enemyReload()
    {
        if (Vector3.Distance(encounters[currEnemyRef].transform.position, enemyPlace) > 0.01f)
        {
            encounters[currEnemyRef].transform.position = Vector3.MoveTowards(encounters[currEnemyRef].transform.position, enemyPlace, moveSpeed * Time.deltaTime);
        }
        else
        {
            resetEnemy = false;
            encounters[currEnemyRef].GetComponent<Enemy>().isAttacking = true;
            encounters[currEnemyRef].GetComponent<Enemy>().ProgressionMultiplier();

        }
    }

    public bool IsListFullOfNull() {
        return encounters != null && encounters.All(item => item == null);
    }

    IEnumerator resetBattle() {
        sparkMove.boostMult = 10;
        ceaseFire.inBetween = true;
        StartCoroutine(roboStats.WalkToBattle(timeToResetBattle));
        yield return new WaitForSeconds(timeToResetBattle);
        resetEnemy = true;
        isEnemyDead = false;
        ceaseFire.inBetween = false;
    }

    public GameObject summonEnemy()
    {
        Debug.Log("Summoning");
        int RandomNumber = Random.Range(0, 20);
        if (RandomNumber <= 10)
        {
            newLastEnemy = Instantiate(enemyTypes[0], offscreenEnemies, enemyTypes[0].transform.rotation);        }
        else if (RandomNumber > 10)
        {
            newLastEnemy = Instantiate(enemyTypes[1], offscreenEnemies, enemyTypes[1].transform.rotation);
        }
        return newLastEnemy;
    }
}