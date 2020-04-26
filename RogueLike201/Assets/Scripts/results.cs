using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class results : MonoBehaviour
{
    private GameObject player;
    public Transform usernameTran;
    public Transform scoreTran;
    public Transform highScoreTran;
    public Transform message;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Player play = player.GetComponent<PlayerScript>().playerData;

        string username = play.username;
        int score = player.GetComponent<PlayerScript>().score;
        int highScore = play.HighScore;
        bool bossDefeated = player.GetComponent<PlayerScript>().bossDefeated;

        Destroy(player);

        if (username != "Guest" && score > highScore)
        {
            play.HighScore = score;
            play.NewGamePlus = bossDefeated;
            highScore = score;

            Client client = GetComponentInParent<Client>();
            client.Setup();
            client.updateUser(play);
        }

        usernameTran.GetComponent<TextMeshProUGUI>().text = username;
        scoreTran.GetComponent<TextMeshProUGUI>().text = score.ToString();
        highScoreTran.GetComponent<TextMeshProUGUI>().text = highScore.ToString();

        if (bossDefeated)
        {
            message.GetComponent<TextMeshProUGUI>().text = "Congratulations!";
        }
        else
        {
            message.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }

    }
}
