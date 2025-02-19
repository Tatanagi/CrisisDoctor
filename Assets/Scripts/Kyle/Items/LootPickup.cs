using UnityEngine;

public class LootPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LootItem lootItem = GetComponent<LootItem>();
            if (lootItem != null)
            {
                ProcessLoot(lootItem.lootData, collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void ProcessLoot(Loot loot, GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        switch (loot.lootType)
        {
            case LootType.Ammo:
                Debug.Log("Picked up Ammo: " + loot.lootName);
                break;
            case LootType.Health:
                if (playerHealth != null)
                {
                    playerHealth.Heal(loot.value); // Uses the value from the Loot ScriptableObject
                    Debug.Log($"Picked up Health: {loot.lootName} and healed for {loot.value}");
                }
                break;
            case LootType.Mana:
                Debug.Log("Picked up Mana: " + loot.lootName);
                break;
            default:
                Debug.Log("Picked up: " + loot.lootName);
                break;
        }
    }
}
