using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AnotherWorldProject.AISystem.GOAP.Core
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

        Dictionary<string, int> preConditions;
        Dictionary<string, int> resultConditions;

        


        protected GWorldStates agentStates;
        protected GInventory inventory;
        private void Awake()
        {
            preConditions = new();
            resultConditions = new();
            
            agent = GetComponent<NavMeshAgent>();
            InitializeConditions();
        }
        private void Start()
        {
            agentStates = this.GetComponent<GAgent>().GetAgentStates();
            inventory = this.GetComponent<GAgent>().GetInventory();
        }
        private void Update()
        {
            if (!isRunning) return;
            if(!IsInDistance())
                agent.SetDestination(target.transform.position);
        }
        private void InitializeConditions()
        {
            if (condition != null)
            {
                foreach (GWorldState state in condition)
                {
                    preConditions.Add(state.key, state.value);
                }
            }
            if (result != null)
            {
                foreach (GWorldState state in result)
                {
                    resultConditions.Add(state.key, state.value);
                }
            }
        }
        public GInventory GetWorldInventory()
        {
            return GWorld.Instance.GetWorldInventory();
        }
        public GameObject GetWorldItem(string item)
        {
            return GWorld.Instance.GetWorldInventory().GetInventoryItem(item);
        }
        public GameObject GetWorldLocation(string location)
        {
            return GWorld.Instance.GetWorldLocations().GetLocation(location);
        }
        public GWorldStates GetWorldGameStates()
        {
            return GWorld.Instance.GetGWorldWorldStates();
        }
        public GAgent GetTargetAgent(GameObject target)
        {
            return target.gameObject.GetComponent<GAgent>();
        }
        public bool IsAchievable()
        {
            return true;
        }
        public bool IsAchieveableGiven(Dictionary<string, int> conditionsAchieved)
        {
            foreach (KeyValuePair<string, int> precondition in this.preConditions)
            {
                if (!conditionsAchieved.ContainsKey(precondition.Key))
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
            return preConditions;
        }
        public Dictionary<string, int> GetResultConditions()
        {
            return resultConditions;
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

