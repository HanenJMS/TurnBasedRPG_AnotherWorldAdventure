using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
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
        GWorldStateHandler locationStates = new();
        GInventory inventory = new();

        List<GAgent> clients = new();
        List<GAgent> workers = new();

        public void AddClient(GAgent agent)
        {
            if(!clients.Contains(agent))
            {
                clients.Add(agent);

            }
        }
        public void AddWorker(GAgent worker)
        {
            if(!workers.Contains(worker))
            {
                workers.Add(worker);
            }
        }
        public void RemoveClient(GAgent agent)
        {
            if (clients.Contains(agent))
            {
                clients.Remove(agent);
            }
        }
        public void RemoveWorker(GAgent worker)
        {
            if (workers.Contains(worker))
            {
                workers.Remove(worker);
            }
        }
        void OnEnable()
        {
            if (locationName == "") return;
            GWorld.Instance.GetWorldLocations().AddLocation(locationName, this);
        }
        public GWorldStateHandler GetStateHandler()
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
                agent.GetStateHandler().ModifyState(new(locationState, 1));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out GAgent agent))
            {
                agent.GetStateHandler().ModifyState(new(locationState, -1));
            }
        }
    }

}
