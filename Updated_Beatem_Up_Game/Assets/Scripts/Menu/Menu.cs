﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
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
        Debug.Log("this is working");
        animator.SetTrigger("NextScreen");
    }

    public void LeaveMenu()
    {
        Debug.Log("This is leaveing the menu");
        animator.SetTrigger("BackScreen");
    }

    public void QuitGame()
    {
        Debug.Log("The Game Has quit");
        Application.Quit();
    }
}
