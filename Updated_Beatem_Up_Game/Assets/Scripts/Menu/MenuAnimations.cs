﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAnimations : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
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
    }
    public void SetUpGame()
    {
        // Plays the animation for leaving the start menu
        // of the game and load the start game menu
        animator.SetTrigger("BackScreen");
        animator.SetTrigger("StartingGame");
    }

    public void LeaveSetUp()
    {
        // Plays the animation for leaving the start game menu
        // and load the animation for the start menu
        animator.SetTrigger("ResetGame");
        animator.SetTrigger("NextScreen");
    }

    public void StartGame()
    {
        // loads the game scene 
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
    }

    public void LeaveAbout()
    {
        // Plays the animation for leaving the about screen
        // and plays the animations for going back to the options screen
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("AboutLeave");
        animator.SetTrigger("OptionsMenu");
    }

    public void OptionsMenu()
    {
        // Plays the animation for leaving the start menu
        // and plays the animations for going to the options screen
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("BackScreen");
        animator.SetTrigger("OptionsMenu");
    }

    public void LeaveOptions()
    {
        // Plays the animation for leaving the options menu
        // and plays the animations for going to the start menu
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("LeaveOptions");
        animator.SetTrigger("NextScreen");
    }

    public void QuitGame()
    {
        // Quits the game 
        Debug.Log("The Game Has quit");
        Application.Quit();
    }
}
