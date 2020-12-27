using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource ButtonFX;
    public AudioSource EnterFX;
    public AudioSource OptionsMusic;

    public static Music instance;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<AudioSource>();
        ButtonFX = GameObject.FindGameObjectWithTag("ButtonFX").GetComponent<AudioSource>();
        EnterFX = GameObject.FindGameObjectWithTag("EnterFX").GetComponent<AudioSource>();
        OptionsMusic = GameObject.FindGameObjectWithTag("OptionsMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
