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
    [SerializeField]
    private GameObject GameMenu;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject LevelObjects;
    public TextMeshProUGUI GameResults;
    public TextMeshProUGUI gameTime;
    public TextMeshProUGUI Lives;
    public bool gameIsPaused;
    private Animator animator;
    public GameObject PauseButton, OptionsButton, ExitAbout;

    private void Awake()
    {

        GameMenu = GameObject.Find("GameMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        LevelObjects = GameObject.Find("LevelObjects");
        PauseMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
