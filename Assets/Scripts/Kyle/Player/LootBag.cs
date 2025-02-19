using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;

    [Header("Loot Lists")]
    public List<Loot> ammoLootList = new List<Loot>();
    public List<Loot> healthLootList = new List<Loot>();
    public List<Loot> manaLootList = new List<Loot>();

    private Loot GetDroppedItem(List<Loot> lootList)
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        return possibleItems.Count > 0 ? possibleItems[Random.Range(0, possibleItems.Count)] : null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        List<List<Loot>> allLootLists = new List<List<Loot>> { ammoLootList, healthLootList, manaLootList, };
        List<Loot> selectedLootList = allLootLists[Random.Range(0, allLootLists.Count)];

        Loot droppedItem = GetDroppedItem(selectedLootList);
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootGameObject.AddComponent<LootItem>().lootData = droppedItem;

            float dropForce = 3f;
            Vector2 dropDirection = Random.insideUnitCircle.normalized;
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }

    public void DropLoot()
    {
        InstantiateLoot(transform.position);
    }
}
