using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.AISystem.GOAP
{
    [System.Serializable]
    public abstract class GAction : MonoBehaviour
    {
        [SerializeField] string actionName;
        [SerializeField] float actionCost = 1.0f;
        [SerializeField] protected GameObject target;
        NavMeshAgent agent;
        [SerializeField] float duration = 0f;
        [SerializeField] bool isRunning = false;


        [SerializeField] GWorldState[] condition;
        [SerializeField] GWorldState[] result;

        Dictionary<string, int> inConditions;
        Dictionary<string, int> outConditions;


        [SerializeField] GLocation targetLocation;

        protected GWorldStateHandler agentStates;
        protected GInventory inventory;
        private void Awake()
        {
            inConditions = new();
            outConditions = new();

            agent = GetComponent<NavMeshAgent>();
            InitializeConditions();
        }
        private void Start()
        {
            agentStates = this.GetComponent<GAgent>().GetStateHandler();
            inventory = this.GetComponent<GAgent>().GetInventory();
        }
        private void Update()
        {
            if (!isRunning) return;
            if (!IsInDistance())
                agent.SetDestination(target.transform.position);
        }
        private void InitializeConditions()
        {
            if (condition != null)
            {
                foreach (GWorldState state in condition)
                {
                    inConditions.Add(state.key, state.value);
                }
            }
            if (result != null)
            {
                foreach (GWorldState state in result)
                {
                    outConditions.Add(state.key, state.value);
                }
            }
        }
        public GInventory GetWorldInventory()
        {
            return GWorld.Instance.GetWorldInventory();
        }
        public GameObject GetWorldItem(string item)
        {
            return GWorld.Instance.GetWorldInventory().GetItem(item);
        }
        public GLocation GetWorldLocation(string location)
        {
            return GWorld.Instance.GetWorldLocations().GetLocation(location);
        }
        public GWorldStateHandler GetWorldGameStates()
        {
            return GWorld.Instance.GetGWorldWorldStates();
        }
        public GAgent GetTargetAgent(GameObject target)
        {
            return target.gameObject.GetComponent<GAgent>();
        }
        public GLocation GetTargetGLocation(GameObject target)
        {
            return target.gameObject.GetComponent<GLocation>();
        }
        public bool IsAchievable()
        {
            return true;
        }
        public bool IsAchieveableGiven(Dictionary<string, int> states)
        {
            foreach (KeyValuePair<string, int> precondition in this.inConditions)
            {
                if (!states.ContainsKey(precondition.Key))
                {
                    return false;
                }
            }
            return true;
        }
        public void ExecuteAction()
        {
            isRunning = true;

        }
        public void CancelAction()
        {
            isRunning = false;

        }
        public bool IsRunning()
        {
            return isRunning;
        }
        public bool HasPath()
        {
            return agent.hasPath;
        }
        public bool HasTarget()
        {
            return target != null;
        }
        public bool IsInDistance()
        {
            return Vector3.Distance(target.transform.position, this.transform.position) < 2.25f;
        }
        public Dictionary<string, int> GetPreConditions()
        {
            return inConditions;
        }
        public Dictionary<string, int> GetActionOutConditions()
        {
            return outConditions;
        }
        public float GetActionCost()
        {
            return actionCost;
        }
        public float GetDuration()
        {
            return duration;
        }
        public abstract bool PreActionExecute();
        public abstract bool PostActionExecute();

    }
}

