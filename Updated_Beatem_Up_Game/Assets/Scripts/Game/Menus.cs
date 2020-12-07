using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour
{

    // setting up and sorting the Game menu objects
    // ------------------------------------------------------- menu objects - These are working right now
    [Header("Game Menus")]
    private GameObject GameMenu;
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject LevelObjects;
    [Tooltip("Showing the player how much time is left for the game")]
    public TextMeshProUGUI gameTime;
    public bool gameIsPaused;
    private Animator animator;
    public GameObject PauseButton, OptionsButton, ExitAbout;

    // ------------------------------------------------------- Player UI
    public Slider healthUI;
    public Image playerImage;
    [Tooltip("Showing the player's name")]
    public TextMeshProUGUI playerName;
    [Tooltip("Showing the player how much lives are left")]
    public TextMeshProUGUI livesText;
    [Tooltip("Show the results of the level if you won or lost")]
    public TextMeshProUGUI displayMessage;

    // --------------------------------------------------- Enemy UI
    public GameObject enemyUI;
    public Slider enemySlider;
    public TextMeshProUGUI enemyName;
    public Image enemyImage;

    public float enemyUITime = 4f;

    private float enemyTimer;
    private Player player;

    private void Awake()
    {
        // Setting up the Menu objects
        GameMenu = GameObject.Find("GameMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        LevelObjects = GameObject.Find("LevelObjects");
        PauseMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        healthUI.maxValue = player.maxHealth;
        healthUI.value = healthUI.maxValue;
        playerName.text = player.playerName;
        playerImage.sprite = player.playerImage;
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemyUITime)
        {
            enemyUI.SetActive(false);
            enemyTimer = 0;
        }

        // Pressing the escape key will pause the game
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        // Pause the game to bring up the pause menu
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            GameMenu.SetActive(false);
            PauseMenu.SetActive(true);
            LevelObjects.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseButton);
        }
        else
        {
            Time.timeScale = 1f;
            GameMenu.SetActive(true);
            PauseMenu.SetActive(false);
            LevelObjects.SetActive(true);
        }
    }

    public void MenuScreen()
    {
        Time.timeScale = 1f;
        // loads the game scene
        SceneManager.LoadScene("MainMenu");


    }

    public void UpdateHealth(int amount)
    {
        healthUI.value = amount;
    }

    public void UpdateEnemyUI(int maxHealth, int currentHealth, string name, Sprite image)
    {
        enemySlider.maxValue = maxHealth;
        enemySlider.value = currentHealth;
        enemyName.text = name;
        enemyImage.sprite = image;
        enemyTimer = 0;
        enemyUI.SetActive(true);
    }

    public void UpdateLives()
    {
        livesText.text = "x " + FindObjectOfType<GM>().PlayerLives.ToString();
    }

    public void UpdateDisplayMessage(string message)
    {
        displayMessage.text = message;
    }
}
