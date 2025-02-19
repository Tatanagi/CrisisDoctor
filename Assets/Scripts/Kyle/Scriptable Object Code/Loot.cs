using UnityEngine;

public enum LootType
{
    Ammo,
    Health,
    Mana,
}

[CreateAssetMenu(fileName = "NewLoot", menuName = "ScriptableObject/Loot", order = 1)]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;
    public int value;
    public LootType lootType; // Categorization of loot

}
