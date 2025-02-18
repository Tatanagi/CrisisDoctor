using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loot", menuName = "ScriptableObject/Loot", order = 1)]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;
    public int value;

    public Loot(Sprite lootSprite, string lootName, int dropChance)
    {
        this.lootSprite = lootSprite;
        this.dropChance = dropChance;
    }
}
