﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public string startGame;

    public GameObject startMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene("METEDELJUEGOAQUI");
    }

    public  void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}