using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveVal;
    public GameObject projectile;
    public GameObject crossHair;
    public Transform projectileSpawn;
    private float timeBtwShots;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 mouseDirection = new Vector2(mousePosition.x,mousePosition.y);
        //Debug.Log("mouseDirection: " + mouseDirection + ", player:" + rb.position);
        crossHair.transform.position = mouseDirection;

        Vector2 playertoCursor = new Vector2(mousePosition.x - rb.position.x, mousePosition.y - rb.position.y);
        float angle = Vector2.SignedAngle(new Vector2(0.0f,1.0f), playertoCursor);
        rb.rotation = angle;


        Debug.Log(angle);

        if (Input.GetKey(KeyCode.W))
        {
            //rb.rotation = 0.0f;
            rb.position = new Vector2(rb.position.x, rb.position.y + (moveVal * Time.deltaTime));
            //crossHair.transform.position = new Vector2(crossHair.transform.position.x, crossHair.transform.position.y +(moveVal*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.rotation = 90.0f;
            rb.position = new Vector2(rb.position.x - (moveVal * Time.deltaTime), rb.position.y );
            //crossHair.transform.position = new Vector2(crossHair.transform.position.x - (moveVal * Time.deltaTime), crossHair.transform.position.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.rotation = 180.0f;
            rb.position = new Vector2(rb.position.x, rb.position.y - (moveVal * Time.deltaTime));
            //crossHair.transform.position = new Vector2(crossHair.transform.position.x, crossHair.transform.position.y - (moveVal * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.rotation = 270.0f;
            rb.position = new Vector2(rb.position.x + (moveVal * Time.deltaTime), rb.position.y);
            //crossHair.transform.position = new Vector2(crossHair.transform.position.x + (moveVal * Time.deltaTime), crossHair.transform.position.y);
        }

        if (timeBtwShots <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectile, transform.position, transform.rotation);
                    
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
