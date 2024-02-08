using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GAgent : MonoBehaviour
    {
        [SerializeField] List<GAction> agentActionList;
        [SerializeField] protected Dictionary<GAgentGoal, int> agentGoals = new();
        GAgentGoal currentGoal;
        protected GInventory inventory = new();
        protected GWorldStates agentStates = new();
        GoalActionPlanner goalActionPlanner;
        Queue<GAction> goalActionQueue;
        GAction currentAction;



        protected virtual void Start()
        {
            agentActionList = new List<GAction>(this.GetComponents<GAction>());
        }


        void CompleteAction()
        {
            currentAction.CancelAction();
            currentAction.PostActionExecute();
            currentAction = null;
        }
        private void LateUpdate()
        {
            if (currentAction != null && currentAction.IsRunning())
            {
                if (currentAction.HasPath() && currentAction.IsInDistance())
                {
                    CompleteAction();
                }
                return;
            }
            if (goalActionQueue == null || goalActionPlanner == null)
            {
                goalActionPlanner = new();
                var sortedGoals = from goals in agentGoals orderby goals.Value descending select goals;
                foreach (KeyValuePair<GAgentGoal, int> sortedGoal in sortedGoals)
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
        public GAgentGoal GetCurrentGoal()
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
        public Dictionary<GAgentGoal, int> GetGoals() => agentGoals;
    }
}

