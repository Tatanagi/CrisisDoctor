using UnityEngine;

public class LootPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ensure player has the "Player" tag
        {
            Debug.Log("Loot Collected: " + gameObject.name);
            Destroy(gameObject); // Destroy the loot object
        }
    }
}
