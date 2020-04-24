using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{
    public Player player;
    public Transform username;
    public Transform money;
    public Transform score;
    public Transform health;
    public Transform weapon;
    private int scoreCount;
    private int healthCount;

    void Awake()
    {
        scoreCount = 0;
        healthCount = 100;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        username.GetComponent<TextMeshProUGUI>().text = player.username;
        money.GetComponent<TextMeshProUGUI>().text = "Money: " + player.money;
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        health.GetComponent<TextMeshProUGUI>().text = "Health: " + healthCount;
    }

}
