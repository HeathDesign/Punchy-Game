using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //if there hasnt been a attack recently
        if (timeBtwAttack <= 0)
        {

            //if the user presses the E key
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Attack Pressed");

                //array of all the colliders within
                //attack range that are on the enemy layer
                 Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                //Debug.Log(enemiesToDamage[0]);

                //apply damage to the enemies that we hit
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehavior>().TakeDamage(damage);
                    Debug.Log("HIT!");
                }

                //player attacked, restart time between attacks
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            //player can't attack, keep incrementing attack timer
            timeBtwAttack -= Time.deltaTime;
            //Debug.Log(timeBtwAttack);
        }
    }

    //when the object is clicked, show the attack range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
