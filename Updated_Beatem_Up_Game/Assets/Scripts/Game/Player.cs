using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // setting up and sorting the player's objects
    [Header("Player Status")]
    [Tooltip("Adjust Player Speed")]
    public float playerMoveSpeed;
    [Tooltip("Adjust Player Jump Height")]
    public float jumpForce = 400;
    [Tooltip("Adjust Player Distance from the top of the screen to bottom")]
    public float minHeight, maxHeight;
    [Tooltip("Adjust how the Player has for life until dying")]
    public int playerLife = 10;
    [Tooltip("checking if the player attack gameobejct can attack")]
    public GameObject attacking;
    [Tooltip("Set a name for the Player")]
    public string playerName;
    [Tooltip("Setting a image to show what the player will look like")]
    public Sprite playerImage;
    [Tooltip("Geting the rigidbody from the player")]
    private Rigidbody rb;
    [Tooltip("Getting the groundcheck from the player")]
    private Transform groundCheck;
    [Tooltip("Seeing if the player is on the ground")]
    private bool onGround;
    [Tooltip("checking if the player can jump")]
    private bool jump = false;
    [Tooltip("checking if the player can attack")]
    private bool attack = false;
    private bool facingRight = true;

    /*
    public AudioClip collisionSound, jumpSound, healthItem;
    public int currentHealth;
    public int playerAttack;
    public int lives;
    public GameObject healthBar;
    private float currentSpeed;
    private Animator anim;
    private bool isDead = false;
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

        if (Input.GetKeyDown("mouse 0"))
        {
            attack = true;
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

        if (xInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (xInput < 0 && facingRight)
        {
            Flip();
        }

        if (attack)
        {
            attack = false;
            attacking.SetActive(true);
        }
        else
        {
            attacking.SetActive(false);
        }

        float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minWidth + 1, maxWidth - 1), rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));

    }

    void Flip()
    {
        // fliping the player left or right to attack 
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
