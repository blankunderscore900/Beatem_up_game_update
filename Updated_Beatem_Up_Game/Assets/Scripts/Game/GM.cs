using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GM : MonoBehaviour
{

    // --------------------------------------------------------------------------- player objects
    [Header("Player")]
    [Tooltip("Adjust how much live the player has")]
    public int PlayerLives;
    [Tooltip("Selecting what character will show in the game")]
    public int characterIndex;
    [Tooltip("Adjust how much health the player has")]
    public int PH;
    /*
    public GameObject[] player;
    public Slider HealthUI;
    public Image playerImage;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI disPlayMessage;
    private Player playerUI;
    */
    //  ---------------------------------------------------------------------------- enemy objects
    [Header("Enemy")]
    [Tooltip("list of enemy objects")]
    /*
    public GameObject enemyUI;
    public Slider enemySlider;
    public TextMeshProUGUI enemyName;
    public Image enemyImage;
    public float enemyUITimer = 4f;
    private float enemyTimer;
    public GameObject[] waves;
    */

    // instance
    public static GM instance;

    private void Awake()
    {
        // Makeing sure that the game manager get does not get destory and only have one loaded at a time
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        //Instantiate(player[PlayerLives], transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        // UI items
        //player = FindObjectOfType<Player>();
        //HealthUI.maxValue = player.maxHealth;
        //HealthUI.value = HealthUI.maxValue;
        //playerName.text = player.playerName;
        //playerImage.sprite = player.playerImage;
        //UpdateLives();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        // checking the timer for the enemy
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemyUITimer)
        {
            enemyUI.SetActive(false);
            enemyTimer = 0;
        }
        */
    }


    public void MenuScreen()
    {
        Time.timeScale = 1f;
        // loads the game scene
        SceneManager.LoadScene("MainMenu");


    }


    // --------------------------------------------------------------- player UI's

    public void UpdateHealth(int amount)
    {
        //PH = amount;
        //HealthUI.value = amount;
    }

    public void UpdateLives()
    {
        //livesText.text = "x " + FindObjectOfType<GameManager>().lives.ToString();
    }

    public void UpdateDisplayMessage(string message)
    {
        //displayMessage.text = message;
    }

    // --------------------------------------------------------------- Enemy UI's
    /*
    public void UpdateEnemyUI(int maxHealth, int currentHealth, string name, Sprite image)
    {
        enemySlider.maxValue = maxHealth;
        enemySlider.value = currentHealth;
        enemyName.text = name;
        enemyImage.sprite = image;
        enemyTimer = 0;
        enemyUI.SetActive(true);
    }
    */
}
