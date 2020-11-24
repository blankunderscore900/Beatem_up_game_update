using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // setting up and sorting the player's objects
    [Header("Player Status")]
    public float playerMoveSpeed;
    public int playerLife;
    public int playerAttack;
    public int lives;
    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Placing the health bar at the top of the menu
    private void PlayerHealthBar(float curHealth)
    {
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(curHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

}
