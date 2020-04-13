using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y + 3.33f, -10.0f);
    }
}
