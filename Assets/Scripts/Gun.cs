using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    public int maxAmmo = 20;
    private float nextFireTime = 0f;
    public AudioSource fireSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire") && Time.time >= nextFireTime)
        {
            if(maxAmmo > 0)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        maxAmmo -= 1;
        fireSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
        Destroy(bullet, 2f); 
    }
}