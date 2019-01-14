﻿using System.Collections;
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
        if (timeBtwAttack <= 0)
        {

        
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Attack Pressed");
                 Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                //Debug.Log(enemiesToDamage[0]);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehavior>().TakeDamage(damage);
                    Debug.Log("HIT!");
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            //Debug.Log(timeBtwAttack);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}