using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    public float enemyMoveSpeed;
    public int enemyLife;
    public int enemyAttack;
    public float minHeight, maxHeight;
    public float damageTime = 0.5f;
    public int maxHealth;
    public float attackRate = 1f;
    public string enemyName;
    public Sprite enemyImage;
    public AudioClip collisonSound, deathSound;

    // private enemy objects
    private Rigidbody rb;
    private Transform groundCheck;
    private Transform target;
    private float walkTimer;
    private float currentSpeed;
    private float nextAttack;
    private float zForce;
    private bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetDistince = target.position - transform.position;
        float hForce = targetDistince.x / Mathf.Abs(targetDistince.x);
        if (walkTimer >= Random.Range(1f, 2f))
        {
            zForce = Random.Range(-1, 2);
            walkTimer = 0;
        }

        if (Mathf.Abs(targetDistince.x) < 1.5f)
        {
            hForce = 0;
        }

        if (!damaged)
            rb.velocity = new Vector3(hForce * currentSpeed, 0, zForce * currentSpeed);

        //anim.SetFloat("Speed", Mathf.Abs(currentSpeed));

        if (Mathf.Abs(targetDistince.x) < 1.5f && Mathf.Abs(targetDistince.z) < 1.5f && Time.time > nextAttack)
        {
            //anim.SetTrigger("Attack");
            currentSpeed = 0;
            nextAttack = Time.time + attackRate;
        }

        rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }

    public void TookDamage(int damage)
    {

    }
}
