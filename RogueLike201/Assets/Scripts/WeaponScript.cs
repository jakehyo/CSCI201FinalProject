using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float timeBtwShots;
    public GameObject projectile;
    public AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void fireWeapon()
    {
        audioData.Play();
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
