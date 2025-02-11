using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Destroy the enemy and the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
