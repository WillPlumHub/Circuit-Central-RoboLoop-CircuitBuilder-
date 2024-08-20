using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionChart : MonoBehaviour
{
    public List<Transform> ChartLocations = new List<Transform>();
    public List<GameObject> ChartEnemies = new List<GameObject>();
    public List<GameObject> CETypes = new List<GameObject>();
    public float moveSpeed = 2f;
    public bool isMoving;

    public void Update()
    {
        if (isMoving)
        {
            for (int i = 0; i < ChartLocations.Count - 1; i++)
            {
                //Debug.Log("state: " + ChartLocations[i].position + " " + ChartEnemies[i].name + ChartEnemies[i].transform.position);
                if (Vector3.Distance(ChartEnemies[i].transform.position, ChartLocations[i].transform.position) > 0.01f)
                {
                    ChartEnemies[i].transform.position = Vector3.MoveTowards(ChartEnemies[i].transform.position, ChartLocations[i].transform.position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                }
            }
        }
    }


    public void RemoveEnemy()
    {
        Destroy(ChartEnemies[0]);
        for (int i = 0; i < ChartEnemies.Count - 1; i++) //shuffle list forwards
        {
            
            //Debug.Log(" chartenemies = " + i);
            ChartEnemies[i] = ChartEnemies[i + 1];
        }
        
    }
    public void AddEnemy(GameObject Enemy)
    {
        string enemyToAdd = Enemy.name.Replace("(Clone)", "");
        Debug.Log("enemy to add: " + enemyToAdd);
        if(enemyToAdd == "SlimeEnemyNeutral")
        {
            ChartEnemies[4] = Instantiate(CETypes[0]);
            Debug.Log("Instatiated " + ChartEnemies[4]);
            ChartEnemies[4].transform.position = ChartLocations[4].transform.position;
        }
        if (enemyToAdd == "PanelBot")
        {
            ChartEnemies[4] = Instantiate(CETypes[1]);
            Debug.Log("Instatiated " +  ChartEnemies[4]);
            ChartEnemies[4].transform.position = ChartLocations[4].transform.position;
        }
    }
}
