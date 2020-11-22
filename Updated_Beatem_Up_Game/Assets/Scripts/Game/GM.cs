using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    // setting up and sorting the player's objects
    [Header("Player Status")]
    public float moveSpeed;
    public int playerLife;
    public TextMeshProUGUI gameTime;

    // setting up and sorting the Game menu objects
    [Header("Game Menus")]
    public GameObject Menu;
    public GameObject Pause;
    public static bool gameIsPaused;

    // instance
    public static GM instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        // Pause the game to bring up the pause menu
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Menu.SetActive(false);
            Pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Menu.SetActive(true);
            Pause.SetActive(false);
        }
    }
}
