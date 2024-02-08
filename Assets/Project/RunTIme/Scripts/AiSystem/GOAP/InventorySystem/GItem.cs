using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GItem : MonoBehaviour
    {
        [SerializeField] string itemName;
        [SerializeField] string worldState;
        void Start()
        {
            if (itemName == "") return;
            GWorld.Instance.GetWorldInventory().AddInventoryItem(itemName, this.transform.gameObject);
            if (worldState == "") return;
            GWorld.Instance.GetGWorldWorldStates().ModifyState(new(worldState, 1));
        }
    }
}

