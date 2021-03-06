﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnCollisionScript : MonoBehaviour {

    public float nerfTime;
    public float amountReduce;
    private GameObject gameManager;
    private AudioSource audioSource;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameManager.GetComponent<GameManagerScript>().paused)
        {
            collision.gameObject.GetComponentInParent<PlayerScript>().ReduceSpeed(nerfTime,amountReduce);
            audioSource.Play();
        }
    }
}
