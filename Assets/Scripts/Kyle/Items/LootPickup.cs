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
                ProcessLoot(lootItem.lootData);
                Destroy(gameObject);
            }
        }
    }

    private void ProcessLoot(Loot loot)
    {
        switch (loot.lootType)
        {
            case LootType.Ammo:
                Debug.Log("Picked up Ammo: " + loot.lootName);
                break;
            case LootType.Health:
                Debug.Log("Picked up Health: " + loot.lootName);
                break;
            case LootType.Mana:
                Debug.Log("Picked up Weapon: " + loot.lootName);
                break;
            default:
                Debug.Log("Picked up: " + loot.lootName);
                break;
        }
    }
}
