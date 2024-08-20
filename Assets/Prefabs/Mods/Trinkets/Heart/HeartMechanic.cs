using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMechanic : MonoBehaviour
{
    RobotStatus roboStats;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        roboStats = FindObjectOfType<RobotStatus>();
        level = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        roboStats.RoboMaxHealth += 1 + (2 * (level - 1));
        roboStats.RoboHealth += 1 + (2 * (level - 1));
    }
}
