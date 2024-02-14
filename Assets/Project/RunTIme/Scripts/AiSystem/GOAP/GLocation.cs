using AnotherWorldProject.AISystem.GOAP.StateSystem;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP
{
    public class GLocation : MonoBehaviour
    {
        [SerializeField] string locationName;
        [SerializeField] string locationState;
        [SerializeField] string[] intialAgentStates;
        [SerializeField] string[] desiredAgentStates;
        [SerializeField] int maxCapacity;
        [SerializeField] int currentCapacity;
        [SerializeField] Transform locationEntrance;
        GWorldStates locationStates = new();
        GInventory inventory = new();
        void Start()
        {
            if (locationName == "") return;
            GWorld.Instance.GetWorldLocations().AddLocation(locationName, this);
        }
        public GWorldStates GetStates()
        {
            return locationStates;
        }
        public GInventory GetInventory()
        {
            return inventory;
        }
        public Transform GetEntrance()
        {
            return locationEntrance;
        }
        public int GetCapacity()
        {
            return maxCapacity;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out GAgent agent))
            {
                agent.GetAgentStates().ModifyState(new(locationState, 1));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out GAgent agent))
            {
                agent.GetAgentStates().ModifyState(new(locationState, -1));
            }
        }
    }

}
