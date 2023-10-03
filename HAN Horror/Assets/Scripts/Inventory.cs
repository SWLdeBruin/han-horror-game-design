using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Key> keys = new();

    public void AddItem(Key itemToAdd)
    {
        keys.Add(itemToAdd);
    }
    public void RemoveItem(Key itemToRemove)
    {
        keys.Remove(itemToRemove);
    }
    public List<Key> GetKeys() { return keys; }
}
