using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public float speed;
    public float nearDistance;
    public float stoppingDistance;
    public float startTimeBtwShots;
    public bool stationary;
    public float aggroDistance;
    private float timeBtwShots;
    private Vector3 targ;
    private Transform player;
    public GameObject shot;
    public int scorePoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>().alive)
        {
            if (health <= 0)
            {
                //Debug.Log("DESTRUCTION");
                // Update Kill
                player.GetComponent<PlayerScript>().addScore(scorePoints);
                Destroy(gameObject);
            }

            if (player.GetComponent<PlayerScript>().alive)
            {
                targ = player.transform.position;
            }
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90.0f));

            if (Vector2.Distance(transform.position, player.position) < aggroDistance)
            {
                //shoot
                if (timeBtwShots <= 0)
                {
                    Debug.Log("Shooting");
                    Instantiate(shot, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }

                if (!stationary)
                {
                    //move
                    if (Vector2.Distance(transform.position, player.position) < nearDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                    }
                    else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    }
                    else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
                    {
                        transform.position = this.transform.position;
                    }
                }
            }

            //Time Between Shots
            if (timeBtwShots <= 0)
            {
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

       
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
    }
}
