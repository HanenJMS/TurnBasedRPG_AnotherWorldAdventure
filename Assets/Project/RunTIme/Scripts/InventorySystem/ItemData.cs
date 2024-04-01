using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AnotherWorldProject.InventorySystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item/new Item")]
    public class ItemData : ScriptableObject
    {
        //this will only describe the base item. such as resources having constants.
        [SerializeField] string itemName;
        [TextArea]
        [SerializeField] string description;
        [SerializeField] Image image;
        [SerializeField] Sprite itemSprite;
        [SerializeField] GameObject worldItemPrefab;
    }
}

