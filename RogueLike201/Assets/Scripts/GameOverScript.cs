﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text gameOver;
    private float timer = 0.0f;
    private float fiveSec = 5.0f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<PlayerScript>().alive)
        {
            gameOver.enabled = true;
            timer += Time.deltaTime;
            
        }
        if (timer >= fiveSec)
        {
            //use scenechanger to go to main menu
        }
    }
}
