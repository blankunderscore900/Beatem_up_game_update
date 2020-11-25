using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // setting up and sorting the player's objects
    [Header("Player Status")]
    public float playerMoveSpeed;
    public float jumpForce = 400;
    public float minHeight, maxHeight;
    public int playerLife = 10;
    public string playerName;
    public Sprite playerImage;
    private Rigidbody rb;
    private Transform groundCheck;
    private bool onGround;
    private bool jump = false;
    /*
    public AudioClip collisionSound, jumpSound, healthItem;
    public int currentHealth;
    public int playerAttack;
    public int lives;
    public GameObject healthBar;
    private float currentSpeed;
    private Animator anim;
    private bool isDead = false;
    private bool facingRight = true;
    private AudioSource audioS;
    */
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if(Input.GetButtonDown("Jump") && onGround)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(xInput * playerMoveSpeed, rb.velocity.y, zInput * playerMoveSpeed);

        if (jump)
        {
            jump = false;
            Debug.Log("The jump is working");
            rb.AddForce(Vector3.up* jumpForce);
        }
    }

    //Placing the health bar at the top of the menu
    private void PlayerHealthBar(float curHealth)
    {
        //healthBar.transform.localScale = new Vector3(Mathf.Clamp(curHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void TookDamge(int damage)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>(); 
        /*if( Player != null)
        {
            Player.TookDamage(playerAttack);
        }
        */
    }

}
