using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    [Tooltip("Adjust the enemy movement Speed")]
    public float enemyMoveSpeed;
    [Tooltip("Adjust the enemy attack")]
    public int enemyAttack;
    [Tooltip("Adjust the enemy movement distance from the top of the screen to the bottom")]
    public float minHeight, maxHeight;
    [Tooltip("Adjust the enemy stun state after getting hit")]
    public float damageTime = 0.5f;
    [Tooltip("Adjust the enemy's health")]
    public int maxHealth;
    [Tooltip("Adjust the enemy attack rate")]
    public float attackRate = 1f;
    [Tooltip("Adjust the enemy's name")]
    public string enemyName;
    [Tooltip("Adjust the enemy's image")]
    public Sprite enemyImage;
    [Tooltip("Adjust the enemy's sound affect of getting hit and dieing")]
    public AudioClip collisionSound, deathSound;


    private float currentHealth;
    private float currentSpeed;
    private Rigidbody rb;
    protected Animator anim;
    private Transform groundCheck;
    private bool onGround;
    protected bool facingRight = false;
    private Transform target;
    protected bool isDead = false;
    private float zForce;
    private float walkTimer;
    private bool damaged = false;
    private float damageTimer;
    private float nextAttack;
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        target = FindObjectOfType<Player>().transform;
        currentHealth = maxHealth;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("OnGround", onGround);
        anim.SetBool("Dead", isDead);

        if (!isDead)
        {
            facingRight = (target.position.x < transform.position.x) ? false : true;
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (damaged && !isDead)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageTime)
            {
                damaged = false;
                damageTimer = 0;
            }
        }

        walkTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 targetDistince = target.position - transform.position;
        float hForce = targetDistince.x / Mathf.Abs(targetDistince.x);
        if (!isDead)
        {
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
        }
        rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }


    public void TookDamage(float damage)
    {
        if (!isDead)
        {
            damaged = true;
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            //PlaySong(collisionSound);
            //FindObjectOfType<GM>().UpdateEnemyUI(maxHealth, currentHealth, enemyName, enemyImage);
            if (currentHealth <= 0)
            {
                isDead = true;
                rb.AddRelativeForce(new Vector3(3, 5, 0), ForceMode.Impulse);
                PlaySong(deathSound);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

    void ResetSpeed()
    {
        currentSpeed = enemyMoveSpeed;
    }

    public void PlaySong(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }
}
