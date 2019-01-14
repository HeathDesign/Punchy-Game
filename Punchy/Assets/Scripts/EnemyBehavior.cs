using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //set the enemies health value
    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        //check to see if enemey still has hp
        if (health <= 0)
        {
            //destroy the enemy
            Destroy(gameObject);

            //TODO add some points or drop some loot
        }
    }


    public void TakeDamage(int d)
    {
        //subtract the hit damage from health
        health -= d;
        Debug.Log(health);

        //TODO add some reactions to being hit
    }

}
