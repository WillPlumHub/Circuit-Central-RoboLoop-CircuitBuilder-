using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float firingSpeed;
    public float despawnTime;
    public bool inMotion;

    void Awake()
    {
        inMotion = true;
    }

    void Update()
    {
        if (inMotion)
        {
            this.gameObject.transform.Translate(Vector3.right * firingSpeed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if(collision.gameObject.tag == "Enemy")
        {
            //This should also trigger the enemy's "take damage" animation
            Destroy(gameObject, .3f);
            inMotion = false;
        }
        else
        {
                Destroy(this.gameObject, despawnTime);
        }
    }
}
