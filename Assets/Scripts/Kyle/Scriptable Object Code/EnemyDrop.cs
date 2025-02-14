using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Drops", menuName = "ScriptableObject/Enemy Drops", order = 1)]
public class EnemyDrop : ScriptableObject
{
    // Start is called before the first frame update
    public string ItemName;
    public int ItemID;

    [Space(10)]
    public GameObject ItemPrefab;
    public Texture Icon;

    [Tooltip("To increase the scale of the tree")]
    [Header("Item Value")]
    public int ItemValue;
}
