using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private Vector3 bgPosition;
    private Vector3 bgVelocity;
    private bool moveLeft;
    private bool moveDown;
    private Vector3 bgEdges;

    // Start is called before the first frame update
    void Start()
    {
        bgPosition = new Vector3(0.0f, 0.0f, 0.0f);
        bgVelocity = new Vector3(0.5f, 0.5f, 0.0f);
        bgEdges = new Vector3(250f, 200f, 0.0f);
        moveLeft = true;
        moveDown = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bgPosition.x == bgEdges.x)
        {
            bgVelocity.x = -bgVelocity.x;
        }

        if (bgPosition.y == bgEdges.y)
        {
            bgVelocity.y = -bgVelocity.y;
        }

        transform.position = bgPosition + bgVelocity;
    }
}