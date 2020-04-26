using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //Enemy take damage
                hitInfo.collider.GetComponent<EnemyScript>().TakeDamage(damage);
                DestroyProjectile();
            }
            if (hitInfo.collider.CompareTag("Boss"))
            {
                //Boss take damage
                hitInfo.collider.GetComponent<BossScript>().TakeDamage(damage);
                DestroyProjectile();
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
