using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject crosshair;
    private Transform enemy; // Reference to the enemy

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        Cursor.visible = false; // Hide the default cursor

        // Find the enemy object
        EnemyMovement enemyMovement = FindObjectOfType<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemy = enemyMovement.transform;
        }
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Convert mouse position to world space
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Move crosshair to follow the mouse
        if (crosshair != null)
        {
            crosshair.transform.position = mousePos;
        }

        // Run away from enemy if too close
        if (enemy != null)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);
            if (distance < 2f) // If enemy is too close, move in the opposite direction
            {
                Vector2 directionAway = (transform.position - enemy.position).normalized;
                movement += directionAway; // Add escape movement
            }
        }
    }

    void FixedUpdate()
    {
        // Move player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotate player to face the mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
