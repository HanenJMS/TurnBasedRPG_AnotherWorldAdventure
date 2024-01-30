using System.Collections;
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
        [SerializeField] GameObject target;
        NavMeshAgent agent;
        [SerializeField] float duration = 0f;
        [SerializeField] bool isRunning = false;

        [SerializeField] GWorldState[] condition;
        [SerializeField] GWorldState[] result;

        Dictionary<string, int> preConditions;
        Dictionary<string, int> resultConditions;

        GWorldStates agentStates;

        private void Awake()
        {
            preConditions = new();
            resultConditions = new();
            agent = GetComponent<NavMeshAgent>();
            InitializeConditions();
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

        public bool IsAchievable()
        {
            return true;
        }
        public bool IsPreConditionsMet(Dictionary<string, int> conditionsAchieved)
        {
            foreach(KeyValuePair<string, int> precondition in this.preConditions)
            {
                if(!conditionsAchieved.ContainsKey(precondition.Key))
                {
                    return false;
                }
            }
            return true;
        }
        public void ExecuteAction()
        {
            isRunning = true;
            agent.SetDestination(target.transform.position);
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
            return agent.remainingDistance <= agent.stoppingDistance;
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
        public abstract bool PreActionExecute();
        public abstract bool PostActionExecute();
    }
}

