using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    RobotStatus robotStats;
    public int level = 1;
    void Start()
    {
        robotStats = FindObjectOfType<RobotStatus>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int procs = 5;
        AddHealthOverTime(procs + 2 * level, (int)1+(level / 3));
    }

    IEnumerator AddHealthOverTime(int Procs, int HealAmount)
    {
        for(int i = 0; i < Procs; i++)
        {
            robotStats.RoboHealth += HealAmount;
            yield return new WaitForSeconds(2f);
        }
    }
}
