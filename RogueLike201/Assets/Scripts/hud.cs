using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{
    public Transform username;
    public Transform money;
    public Transform score;
    public Transform health;
    public Transform weapon;
    private int scoreCount;
    private int healthCount;
    private GameObject Player;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        scoreCount = 0;
        healthCount = 100;
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player);

        username.GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerScript>().playerData.username;
        money.GetComponent<TextMeshProUGUI>().text = "Money: " + Player.GetComponent<PlayerScript>().playerData.money;
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount;
        health.GetComponent<TextMeshProUGUI>().text = "Health: " + healthCount;
    }

    void Update()
    {
        username.GetComponent<TextMeshProUGUI>().text = Player.GetComponent<PlayerScript>().playerData.username;
        money.GetComponent<TextMeshProUGUI>().text = "Money: " + Player.GetComponent<PlayerScript>().playerData.money;
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreCount;
        health.GetComponent<TextMeshProUGUI>().text = "Health: " + healthCount;
    }

}
