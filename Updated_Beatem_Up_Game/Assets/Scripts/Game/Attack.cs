﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Player player = other.GetComponent<Player>();
        if(enemy != null)
        {
            float enemyDamage = damage * FindObjectOfType<GM>().enemyAttack;
            enemy.TookDamage(enemyDamage);
        }
        if(player != null)
        {
            player.TookDamage(damage);
        }    
    }
}
