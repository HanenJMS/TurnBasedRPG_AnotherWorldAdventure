using UnityEngine;

namespace AnotherWorldProject.InventorySystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item/new Item")]
    public class ConsumeableItem : ItemData
    {
        //this will only describe the base item. such as resources having constants.
        [SerializeField] int modiifer;
    }
}

