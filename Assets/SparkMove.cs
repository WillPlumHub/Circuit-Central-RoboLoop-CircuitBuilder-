using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMove : MonoBehaviour {

    [SerializeField] public List<Transform> Nodes;
    public GameObject Spark;
    public float moveSpeed;
    private int currNodeIndex;

    // Update is called once per frame
    void Update() {
        if (Nodes == null || Nodes.Count == 0) return;
        moveTowardsNode();
    }

    private void moveTowardsNode() {
        Transform targetNode = Nodes[currNodeIndex];
        float step = moveSpeed * Time.deltaTime;

        Spark.transform.position = Vector3.MoveTowards(Spark.transform.position, targetNode.position, step);
        if (Vector3.Distance(Spark.transform.position, targetNode.position) < 0.00001f) {
            currNodeIndex++;
            if(currNodeIndex >= Nodes.Count) {
                Spark.gameObject.SetActive(false);
                if (Input.GetButton("Jump"))
                {
                    Spark.gameObject.SetActive(true);
                    currNodeIndex = 0;
                }
            }
        }
    }
}
