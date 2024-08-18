using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMove : MonoBehaviour {

    [SerializeField] public List<Transform> Nodes;
    public GameObject Spark;
    public float moveSpeed;
    public float boostMult = 1;
    public float boostAddition = 2;
    public float decrement = 1;
    private int currNodeIndex;

    public bool moving = true;


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

                if (Input.GetButton("Jump")) {
                    Spark.gameObject.SetActive(true);
                    currNodeIndex = 0;
                    boostMult = boostAddition; //Reference boostAddition, that'll effect the starting boost of the spark
                }
            }
        }
    }
}
