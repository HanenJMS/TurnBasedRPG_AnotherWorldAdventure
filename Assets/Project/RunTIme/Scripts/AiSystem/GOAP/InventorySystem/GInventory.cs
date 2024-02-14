using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP
{
    public class GInventory
    {
        Dictionary<string, List<GameObject>> inventory = new();
        /// <summary>
        /// Retrieving an item from a list based inventory.
        /// </summary>
        /// <param name="itemType">item name</param>
        /// <returns>returns GameObject</returns>
        public GameObject GetItem(string itemType)
        {
            if (!inventory.ContainsKey(itemType)) return null;
            if (inventory[itemType].Count == 0) return null;
            GameObject item = inventory[itemType][0];
            return item;
        }

        public void AddItem(string itemType, GameObject item)
        {
            if (inventory.ContainsKey(itemType)) inventory[itemType].Add(item);
            else
            {
                inventory.Add(itemType, new());
                inventory[itemType].Add(item);
            }
        }
        public void RemoveItem(string itemType, GameObject item)
        {
            if (!inventory.ContainsKey(itemType)) return;
            if (inventory[itemType].Count == 0)
            {
                inventory.Remove(itemType);
                return;
            }
            inventory[itemType].Remove(item);
        }
        public Dictionary<string, List<GameObject>> GetInventory() => inventory;
        public bool HasItem(string itemType)
        {
            return inventory[itemType].Count == 0 || inventory[itemType] == null;
        }
    }
}

