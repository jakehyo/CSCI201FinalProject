using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveVal;
    public GameObject projectile;
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
        if (Input.GetKey(KeyCode.W))
        {
            rb.rotation = 0.0f;
            rb.position = new Vector2(rb.position.x, rb.position.y + (moveVal * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation = 90.0f;
            rb.position = new Vector2(rb.position.x - (moveVal * Time.deltaTime), rb.position.y );
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.rotation = 180.0f;
            rb.position = new Vector2(rb.position.x, rb.position.y - (moveVal * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation = 270.0f;
            rb.position = new Vector2(rb.position.x + (moveVal * Time.deltaTime), rb.position.y);
        }
        if (timeBtwShots <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectile, projectileSpawn.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
