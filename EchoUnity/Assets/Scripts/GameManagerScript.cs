﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text scoreText;
    public bool timerPoints;
    public AudioClip addPointsSound;
    public GameObject startScreen;
    public GameObject gameOverScreen;

    private GameObject echo;
    private int score;
    private float timerPointsPerSecond;
    private AudioSource audioSource;
    internal bool paused;
    private bool gameOver;

    // Use this for initialization
    void Start () {
        echo = GameObject.Find("Echo");
        startScreen.SetActive(true);
        gameOver = false;
        paused = true;
        Time.timeScale = 0;
        timerPointsPerSecond = 0;
        score = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return) && !gameOver)
        {
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;
            startScreen.SetActive(paused);
        }
        else if(Input.GetKeyDown(KeyCode.Return) && gameOver)
        {
            paused = false;
            Time.timeScale = 1;
            gameOverScreen.SetActive(false);
            score = 0;
            echo.GetComponent<PlayerScript>().restart();
        }

        if (timerPoints)
        {
            if(timerPointsPerSecond >= 1)
            {
                score+=1;
                timerPointsPerSecond = 0;
            }
            else
            {
            timerPointsPerSecond += Time.deltaTime;
            }
        }

        scoreText.text = "Score: " + score;
	}

    public void addPoints(int points)
    {
        audioSource.PlayOneShot(addPointsSound);
        score += points;
    }

    public void GameOver()
    {
        paused = true;
        gameOver = true;
        gameOverScreen.SetActive(true);
    }
}
