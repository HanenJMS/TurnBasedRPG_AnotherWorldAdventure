using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    public class GAgent : MonoBehaviour
    {
        [SerializeField] List<GAction> agentActionList;
        [SerializeField] protected Dictionary<Goal, int> agentGoals = new();
        Goal currentGoal;
        protected GInventory inventory = new();
        protected GWorldStates agentStates = new();
        GoalActionPlanner goalActionPlanner;
        Queue<GAction> goalActionQueue;
        GAction currentAction;

        GActionHandler actionHandler;

        protected virtual void Start()
        {
            actionHandler = GetComponent<GActionHandler>();
            agentActionList = new List<GAction>(this.GetComponents<GAction>());
        }


        int count = 0;
        private void LateUpdate()
        {
            if (actionHandler.HasCurrentActionRunning())
            {
                if (actionHandler.GetCurrentAction().IsInDistance())
                {
                    actionHandler.InvokeComplete();
                }
                return;
            }
            if (goalActionQueue == null || goalActionPlanner == null)
            {
                goalActionPlanner = new();
                var sortedGoals = from goals in agentGoals orderby goals.Value descending select goals;
                foreach (KeyValuePair<Goal, int> sortedGoal in sortedGoals)
                {
                    goalActionQueue = goalActionPlanner.FindPlan(agentActionList, sortedGoal.Key.goal, agentStates);
                    if (goalActionQueue != null)
                    {
                        currentGoal = sortedGoal.Key;
                        break;
                    }
                }
            }
            if (goalActionQueue != null && goalActionQueue.Count == 0)
            {

                // Check if currentGoal is removable
                if (currentGoal.shouldRemoveGoal)
                {

                    // Remove it
                    agentGoals.Remove(currentGoal);
                }
                // Set planner = null so it will trigger a new one
                goalActionPlanner = null;
            }
            if (goalActionQueue != null && goalActionQueue.Count > 0)
            {
                currentAction = goalActionQueue.Dequeue();
                if (currentAction.PreActionExecute())
                {
                    if (currentAction.HasTarget())
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
        public Goal GetCurrentGoal()
        {
            return currentGoal;
        }

        public GWorldStates GetAgentStates()
        {
            return agentStates;
        }
        public GInventory GetInventory()
        {
            return inventory;
        }
        public Dictionary<Goal, int> GetGoals() => agentGoals;
    }
}

