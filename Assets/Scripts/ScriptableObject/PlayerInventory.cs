using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Inventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField]
    private GameEvent inventoryChangedEvent;

    [SerializeField]
    private List<AItem> items = new List<AItem>();
    private void Awake()
    {
        items = new List<AItem>();
    }

    public void RemoveItem(AItem item)
    {
        items.Remove(item);
        inventoryChangedEvent.Raise();
    }

    public void AddItem(AItem item)
    {
        items.Add(item);
        inventoryChangedEvent.Raise();
    }

    public List<AItem> GetItems()
    {
        return items;
    }

    public void Clear()
    {
        items.Clear();
    }

}
