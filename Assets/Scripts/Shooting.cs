using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
          GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);    //Creates bullet 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();                                            //Create rigidbody object to assign the bullet object as a part of it
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
    }
}
