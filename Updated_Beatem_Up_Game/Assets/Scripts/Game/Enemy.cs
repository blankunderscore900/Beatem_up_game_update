using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    public float minHeight, maxHight;
    public float damageTime = 0.5f;
    public int maxHealth;
    public float attackRate = 1f;
    public string enemyName;
    public Sprite enemyImage;
    public AudioClip collisonSound, deathSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
