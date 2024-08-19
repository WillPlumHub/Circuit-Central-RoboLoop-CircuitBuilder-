using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMove : MonoBehaviour {

    #region Variables
    [Header("Node List")]
    [SerializeField] public List<Transform> Nodes;

    [Header("Basic Movement")]
    public GameObject Spark;
    public float moveSpeed;
    public bool moving = true;
    private int currNodeIndex;

    [Header("Boosting")]
    public float boostMult = 1;
    public float boostAddition = 2;
    public float decrement = 1;


    public float timer;
    AudioManager audioManager;
    #endregion
    public PowerBar powerBar;


    private void Start()
    {
        powerBar.powerBarRoutineRunning = false;
        powerBar.powerBarSlider.gameObject.SetActive(false);
        powerBar.powerBarPressSpace.gameObject.SetActive(false);
        powerBar.powerDisplay.gameObject.SetActive(false);
    }
    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update() {
        if (Nodes == null || Nodes.Count == 0) {
            return;
        }
        if (moving) {
            moveTowardsNode();
        }
        if (boostMult > 1) {
            boostMult -= decrement * Time.deltaTime;
        } else if (boostMult < 1) {
            boostMult = 1;
        }

        if (Spark.transform.position != Nodes[Nodes.Count - 1].transform.position) {
            timer += Time.deltaTime;
        } if (timer >= 1) {
            audioManager.PlaySFX(audioManager.SparkMoving);
            timer = 0;
        }
    }

    private void moveTowardsNode() {
        Transform targetNode = Nodes[currNodeIndex];
        float step = (moveSpeed * boostMult) * Time.deltaTime;

        Spark.transform.position = Vector3.MoveTowards(Spark.transform.position, targetNode.position, step);

        if (Vector3.Distance(Spark.transform.position, targetNode.position) < 0.00001f) {
            currNodeIndex++;
            if(currNodeIndex >= Nodes.Count) {
                currNodeIndex = Nodes.Count - 1;
                Spark.gameObject.SetActive(false);

                //start pb routine
                powerBar.powerBarRoutineRunning = true;
                powerBar.powerDisplay.gameObject.SetActive(false);
                powerBar.powerBarSlider.gameObject.SetActive(true);
                powerBar.powerBarPressSpace.gameObject.SetActive(true);

                if (Input.GetButton("Jump")) {

                    //stop powerbar
                    powerBar.powerBarRoutineRunning = false;
                    powerBar.powerDisplay.gameObject.SetActive(true);
                    powerBar.powerBarSlider.gameObject.SetActive(false);
                    powerBar.powerBarPressSpace.gameObject.SetActive(false);

                    //set boost addition
                    boostAddition = powerBar.powerBarSlider.value;

                    //spark
                    audioManager.PlaySFX(audioManager.SparkLaunch);
                    Spark.gameObject.SetActive(true);
                    currNodeIndex = 0;
                    boostMult = boostAddition; //Reference boostAddition, that'll effect the starting boost of the spark

                    //reset power bar to zero
                    powerBar.powerBarSlider.value = 0;
                }
            }
        }
    }
}
