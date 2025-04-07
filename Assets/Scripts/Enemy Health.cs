using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public AudioSource hitSRC;
    public AudioClip hitSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) 
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        hitSRC.PlayOneShot(hitSound, 0.5f);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}