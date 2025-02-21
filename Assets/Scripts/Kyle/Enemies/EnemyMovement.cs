using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 3f;
    public float stopDistance = 1.5f; // Distance at which the enemy stops moving

    void Start()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement != null)
        {
            player = playerMovement.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            // Move towards the player only if beyond the stop distance
            if (distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}

