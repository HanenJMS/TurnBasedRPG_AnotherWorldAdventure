using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP
{
    public class GItem : MonoBehaviour
    {
        [SerializeField] string itemName;
        [SerializeField] string worldState;

        private void OnTriggerEnter(Collider other)
        {
            if (itemName == "") return;
            if (other.gameObject.TryGetComponent<GLocation>(out  GLocation location))
            {
                location.GetInventory().AddItem(itemName, this.transform.gameObject);
                if (worldState == "") return;
                location.GetStates().ModifyState(new(worldState, 1));
            }
            else
            {
                GWorld.Instance.GetWorldInventory().AddItem(itemName, this.transform.gameObject);
                if (worldState == "") return;
                GWorld.Instance.GetGWorldWorldStates().ModifyState(new(worldState, 1));
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (itemName == "") return;
            if (other.gameObject.TryGetComponent<GLocation>(out GLocation location))
            {
                location.GetInventory().RemoveItem(itemName, this.transform.gameObject);
                if (worldState == "") return;
                location.GetStates().ModifyState(new(worldState, -1));
            }
            else
            {
                GWorld.Instance.GetWorldInventory().RemoveItem(itemName, this.transform.gameObject);
                if (worldState == "") return;
                GWorld.Instance.GetGWorldWorldStates().ModifyState(new(worldState, -1));
            }
        }
    }
}

