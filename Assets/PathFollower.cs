using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    Node[] PathNode;
    public GameObject[] Spark;
    public float MoveSpeed;
    float Timer;
    int Currentnode;
    static Vector3 CurrentPositionHolder;
    public float desiredDuration = 3f;


    // Start is called before the first frame update
    void Start() {
        Spark = GameObject.FindGameObjectsWithTag("Spark");
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();
    }

    void CheckNode() {
        Timer = 0;
        CurrentPositionHolder = PathNode[Currentnode].transform.position;
    }

    void DrawLine() {
        for (int i = 0; i < PathNode.Length; i++) {
            if (i < PathNode.Length - 1) {
                Debug.DrawLine(PathNode[i].transform.position, PathNode[i + 1].transform.position, Color.blue);
            }
        }
    }

    void Update() {
        DrawLine();
        Timer += Time.deltaTime * (MoveSpeed/50);
        float percentageCompleted = Timer / desiredDuration;
        foreach (GameObject g in Spark) {
            if (g.transform.position != CurrentPositionHolder)
            {
                //g.transform.position = Vector3.MoveTowards(transform.position, CurrentPositionHolder, Timer);
                g.transform.position = Vector3.Lerp(g.transform.position, CurrentPositionHolder, Timer);
            }
            else
            {
                if (Currentnode < PathNode.Length - 1)
                {
                    Currentnode++;
                    CheckNode();
                } else
                {
                    g.gameObject.SetActive(false);
                    if (Input.GetButton("Jump")) {
                        g.gameObject.SetActive(true);
                        Currentnode = 0;
                    }
                }
            }
        }

       
    }
}
