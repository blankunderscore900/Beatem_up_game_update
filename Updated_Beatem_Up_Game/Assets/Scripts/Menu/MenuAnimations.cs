using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class MenuAnimations : MonoBehaviour
{

    private Animator animator;
    [Header("Buttons")]
    public GameObject MenuFirstButton;
    public GameObject SetUpExit;
    public GameObject OptionsExit;
    public GameObject PlayerOneButton;
    public GameObject OptionsFirstButton;
    public GameObject AboutFirstButton;
    public GameObject AboutExit;
    [Header ("Player UI")]
    public Image playerOne;
    public Image playerTwo;
    public Image playerThree;
    public Image playerFour;
    public float buttonTimer;
    private Color defaultColor;
    public int characterIndex;
    [Header("Music Objects")]
    private Music music;
    [Header("Sound Settings")]
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        music = FindObjectOfType<Music>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuStart()
    {
        // Plays the animation for opening to the start menu of the game
        Debug.Log("this is working");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("MenuStartButton", buttonTimer);

    }
    public void MenuStartButton()
    {
        EventSystem.current.SetSelectedGameObject(MenuFirstButton);
    }
    public void SetUpGame()
    {
        // Plays the animation for leaving the start menu
        // of the game and load the start game menu
        animator.SetTrigger("BackScreen");
        animator.SetTrigger("StartingGame");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("SetUpGameButton", buttonTimer);
        music.MenuMusic.Play();
        music.MenuMusic.loop = true;

    }

    public void SetUpGameButton()
    {

        EventSystem.current.SetSelectedGameObject(PlayerOneButton);
    }

    public void LeaveSetUp()
    {
        // Plays the animation for leaving the start game menu
        // and load the animation for the start menu
        animator.SetTrigger("ResetGame");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("LeaveSetUpButton", buttonTimer);
        music.MenuMusic.Stop();
        music.MenuMusic.loop = false;
    }

    public void LeaveSetUpButton()
    {
        EventSystem.current.SetSelectedGameObject(SetUpExit);
    }

    public void StartGame()
    {
        // loads the game scene
        music.MenuMusic.Stop();
        music.MenuMusic.loop = false;
        SceneManager.LoadScene("Game");
    }

    public void LeaveMenu()
    {
        // Plays the animation for leaving the start menu
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("BackScreen");  
    }

    public void GameAbout()
    {
        // Plays the animation for leaving the options menu
        // and plays the animation for the about page
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("AboutStart");
        animator.SetTrigger("LeaveOptions");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("AboutMenuButton", buttonTimer);

    }

    public void AboutMenuButton()
    {
        EventSystem.current.SetSelectedGameObject(AboutFirstButton);
    }

    public void LeaveAbout()
    {
        // Plays the animation for leaving the about screen
        // and plays the animations for going back to the options screen
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("AboutLeave");
        animator.SetTrigger("OptionsMenu");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("LeaveAboutButton", buttonTimer);
    }
    public void LeaveAboutButton()
    {
        EventSystem.current.SetSelectedGameObject(AboutExit);
    }

    public void OptionsMenu()
    {
        // Plays the animation for leaving the start menu
        // and plays the animations for going to the options screen
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("BackScreen");
        animator.SetTrigger("OptionsMenu");
        EventSystem.current.SetSelectedGameObject(null);
        music.OptionsMusic.Play();
        music.OptionsMusic.loop = true;
        Invoke("OptionsMenuButton", buttonTimer);
    }

    public void OptionsMenuButton()
    {
        EventSystem.current.SetSelectedGameObject(OptionsFirstButton);
    }

    public void LeaveOptions()
    {
        // Plays the animation for leaving the options menu
        // and plays the animations for going to the start menu
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("LeaveOptions");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        music.OptionsMusic.Stop();
        music.OptionsMusic.loop = false;
        Invoke("LeaveOptionsButton", buttonTimer);
    }

    public void LeaveOptionsButton()
    {
        EventSystem.current.SetSelectedGameObject(OptionsExit);
    }

    public void QuitGame()
    {
        // Quits the game 
        Debug.Log("The Game Has quit");
        Application.Quit();
    }

    public void SetLives(int lives)
    {
        FindObjectOfType<GM>().PlayerLives = lives;
    }


    public void PlaySoundEffect()
    {
        music.ButtonFX.Play();
    }
    public void PlayEnterEffect()
    {
        music.EnterFX.Play();
    }
}
