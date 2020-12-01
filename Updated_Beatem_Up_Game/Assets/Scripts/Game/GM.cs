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
    [Header("Game Menus")]
    public GameObject Menu;
    public GameObject Pause;
    public TextMeshProUGUI GameResults;
    public TextMeshProUGUI gameTime;
    public TextMeshProUGUI Lives;
    public bool gameIsPaused;
    private Animator animator;
    public GameObject PauseButton, OptionsButton, ExitAbout;

    [Header("Player"), Tooltip("list of player objects")]
    // player objects
    public GameObject[] player;
    public int PlayerLives;
    public Slider HealthUI;
    public Image playerImage;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI disPlayMessage;
    private Player playerUI;


    [Header("Enemy")]
    [Tooltip("list of enemy objects")]
    // enemy objects
    public GameObject enemyUI;
    public Slider enemySlider;
    public TextMeshProUGUI enemyName;
    public Image enemyImage;
    public float enemyUITimer = 4f;
    private float enemyTimer;
    public GameObject[] enemy;
    public float maxZ, minZ;
    public int numberOfEnemies;
    public float spawnTime;
    public int waves;
    private int currentEnemies;


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

        if(currentEnemies >= numberOfEnemies)
        {
            int enemies = FindObjectsOfType<Enemy>().Length;
            if(enemies <= 0)
            {
                FindObjectOfType<CamFollow>().maxXAndY.x = 200;
                gameObject.SetActive(false);
            }
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

    // ------------------------------------------------------------------------- Spawn Enemies objects

    // spawnEnemies into the level to fight
    void SpawnEnemy()
    {
        bool positionX = Random.Range(0, 2) == 0 ? true : false;
        Vector3 spawnPosition;
        spawnPosition.z = Random.Range(minZ, maxZ);
        if (positionX)
        {
            spawnPosition = new Vector3(transform.position.x + 20, 0, spawnPosition.z);
        }
        else
        {
            spawnPosition = new Vector3(transform.position.x - 20, 0, spawnPosition.z);
        }
        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPosition, Quaternion.identity);
        currentEnemies++;
        if (currentEnemies < numberOfEnemies)
        {
            Invoke("SpawnEnemy", spawnTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<CamFollow>().maxXAndY.x = transform.position.x;
            SpawnEnemy();
        }
    }

    // --------------------------------------------------------------- player UI's

    public void UpdateHealth(int amount)
    {
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
