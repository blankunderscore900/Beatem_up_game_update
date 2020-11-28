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

    [Header("Player & Enemy")]
    private Player player;


    // instance
    public static GM instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // grabbing the player object to be use at the start of the game
        player = FindObjectOfType<Player>(); 
        

    }

    // Update is called once per frame
    void Update()
    {
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
}
