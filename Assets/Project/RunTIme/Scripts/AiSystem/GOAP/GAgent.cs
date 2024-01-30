using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GAgent : MonoBehaviour
    {
        [SerializeField]List<GAction> agentActionList;
        [SerializeField] protected List<GAgentGoal> agentGoalLists = new();
        [SerializeField]protected Dictionary<GAgentGoal, int> agentGoals = new();

        Queue<GAction> goalActionQueue;
        GAction currentAction;
        GAgentGoal currentGoal;

        GGoalActionPlanner goalActionPlanner;
        protected virtual void Start()
        {
            agentActionList = new List<GAction>(this.GetComponents<GAction>());
            foreach (GAgentGoal goals in agentGoalLists)
            {
                agentGoals.Add(goals, 1);
            }
        }


        void CompleteAction()
        {
            currentAction.CancelAction();
            currentAction.PostActionExecute();
        }
        private void LateUpdate()
        {
            if(currentAction != null && currentAction.IsRunning())
            {
                if(currentAction.HasPath() && currentAction.IsInDistance())
                {
                    CompleteAction();
                }
            }
            if(goalActionQueue == null || goalActionPlanner == null)
            {
                goalActionPlanner = new();
                var sortedGoals = from entry in agentGoals orderby entry.Value descending select entry;
                foreach(KeyValuePair<GAgentGoal, int> sortedGoal in sortedGoals)
                {
                    goalActionQueue = goalActionPlanner.FindPlan(agentActionList, sortedGoal.Key.goalState, null);
                    if(goalActionQueue != null)
                    {
                        currentGoal = sortedGoal.Key;
                        break;
                    }
                }
            }
            if(goalActionQueue != null && goalActionQueue.Count > 0)
            {
                currentAction = goalActionQueue.Dequeue();
                if(currentAction.PreActionExecute())
                {
                    if(currentAction.HasTarget())
                    {
                        currentAction.ExecuteAction();
                    }
                }
                else
                {
                    goalActionQueue = null;
                }
            }
        }
    }
}

