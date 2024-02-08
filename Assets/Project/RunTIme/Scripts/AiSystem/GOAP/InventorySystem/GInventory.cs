using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GInventory : MonoBehaviour
    {
        Dictionary<string, Queue<GameObject>> inventory = new();

        /// <summary>
        /// Retrieving an item from a Queue based inventory.
        /// </summary>
        /// <param name="itemKey">item name</param>
        /// <returns>returns GameObject</returns>
        public GameObject GetInventoryItem(string itemKey)
        {
            if (!inventory.ContainsKey(itemKey)) return null;
            if (inventory[itemKey].Count == 0) return null;
            return inventory[itemKey].Dequeue();
        }


        public void AddInventoryItem(string itemKey, GameObject item)
        {
            if (inventory.ContainsKey(itemKey)) inventory[itemKey].Enqueue(item);
            else
            {
                inventory.Add(itemKey, new());
                inventory[itemKey].Enqueue(item);
            }
        }
        public Dictionary<string, Queue<GameObject>> GetInventory() => inventory;
        public bool HasItem(string itemKey)
        {
            return inventory[itemKey].Count == 0 || inventory[itemKey] == null;
        }
    }
}

