using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContent : MonoBehaviour
{
    [SerializeField]
    private List<AItem> items = new List<AItem>();

    [SerializeField]
    private bool dropAll = false;

    public List<AItem> GetRandomLoot()
    {
        List<AItem> itemsLooted = new List<AItem>();
        if (!dropAll)
        {
            itemsLooted.Add((AItem)items[Random.Range(0, items.Count)].Clone());
        }
        else
        {
            foreach (var item in items)
            {
                itemsLooted.Add((AItem)item.Clone());
            }
        }
        return itemsLooted;
    }
}
