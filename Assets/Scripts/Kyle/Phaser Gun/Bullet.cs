using UnityEngine;

public class Bullet : MonoBehaviour
{
    int expAmount = 100;

    void Start()
    {
        Destroy(gameObject, 3f);
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

            PlayerLevel player = FindObjectOfType<PlayerLevel>();
            if (player != null)
            {
                player.GainExp(expAmount);
            }

            // Ensure ScoreManagement instance exists before adding points
            if (ScoreManagement.instance != null)
            {
                ScoreManagement.instance.AddKill(1); // Adds 1 point per enemy
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
