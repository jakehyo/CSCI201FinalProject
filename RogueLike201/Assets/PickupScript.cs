using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public bool isWeapon;
    public int weaponId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isWeapon == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerScript>().addCoin();
            Object.Destroy(gameObject);
        }

        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.E) )
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<WeaponSwitchScript>().setWeapon(weaponId);
            Object.Destroy(gameObject);
        }
    }
}
