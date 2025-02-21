using UnityEngine;

public class Bullet : MonoBehaviour
{
    int expAmount = 100;
    void Start()
    {
        Destroy(gameObject, 3f); // Destroy bullet after 3 seconds if it doesn't hit anything
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            LootBag lootBag = collision.GetComponent<LootBag>();
            if (lootBag != null)
            {
                lootBag.InstantiateLoot(collision.transform.position);
            }

            Destroy(collision.gameObject); // Properly destroy the enemy
            Destroy(gameObject); // Destroy the bullet after hitting the enemy
        }
    }
}