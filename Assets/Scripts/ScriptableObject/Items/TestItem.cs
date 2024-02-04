using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class TestItem : AItem
{
    public override object Clone()
    {
        TestItem tempItem = CreateInstance<TestItem>();

        tempItem.IGPrefab = IGPrefab;
        tempItem.inventorySprite = inventorySprite;
        tempItem.type = type;
        tempItem.bonusStats = bonusStats;

        return tempItem;
    }
}
