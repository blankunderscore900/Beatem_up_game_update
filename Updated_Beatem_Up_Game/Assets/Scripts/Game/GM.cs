using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GM : MonoBehaviour
{
    // setting up and sorting the Game menu objects
    // ------------------------------------------------------- menu objects - These are working right now
    [Header("Game Menus")]
    public GameObject Menu;
    public GameObject Pause;
    public TextMeshProUGUI GameResults;
    public TextMeshProUGUI gameTime;
    public TextMeshProUGUI Lives;
    public bool gameIsPaused;
    private Animator animator;
    public GameObject PauseButton, OptionsButton, ExitAbout;

    // --------------------------------------------------------------------------- player objects
    [Header("Player"), Tooltip("list of player objects")]
    public GameObject[] player;
    public int PlayerLives;
    public int PH;
    public Slider HealthUI;
    public Image playerImage;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI disPlayMessage;
    private Player playerUI;

    //  ---------------------------------------------------------------------------- enemy objects
    [Header("Enemy")]
    [Tooltip("list of enemy objects")]
    public GameObject enemyUI;
    public Slider enemySlider;
    public TextMeshProUGUI enemyName;
    public Image enemyImage;
    public float enemyUITimer = 4f;
    private float enemyTimer;
    public GameObject[] waves;


    // instance
    public static GM instance;

    private void Awake()
    {
        instance = this;
        Instantiate(player[PlayerLives], transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        // Pressing the escape key will pause the game
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }

        // checking the timer for the enemy
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemyUITimer)
        {
            enemyUI.SetActive(false);
            enemyTimer = 0;
        }
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        // Pause the game to bring up the pause menu
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Menu.SetActive(false);
            Pause.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseButton);
        }
        else
        {
            Time.timeScale = 1f;
            Menu.SetActive(true);
            Pause.SetActive(false);
        }
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
        PH = amount;
        HealthUI.value = amount;
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

    public void UpdateEnemyUI(int maxHealth, int currentHealth, string name, Sprite image)
    {
        enemySlider.maxValue = maxHealth;
        enemySlider.value = currentHealth;
        enemyName.text = name;
        enemyImage.sprite = image;
        enemyTimer = 0;
        enemyUI.SetActive(true);
    }
}
