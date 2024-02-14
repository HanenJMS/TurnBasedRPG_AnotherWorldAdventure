using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    [RequireComponent(typeof(GActionHandler), typeof(GoalHandler))]
    public class GAgent : MonoBehaviour
    {
        GInventory inventory = new();
        
        GPlanner gPlanner;
        Queue<GAction> plannedAction;

        GActionHandler actionHandler;
        GoalHandler goalHandler;
        GWorldStateHandler stateHandler = new();
        protected virtual void Start()
        {
            actionHandler = GetComponent<GActionHandler>();
            goalHandler = GetComponent<GoalHandler>();
        }

        public GActionHandler GetActionHandler() => actionHandler;
        public GoalHandler GetGoalHandler() => goalHandler;
        public GWorldStateHandler GetStateHandler() => stateHandler;
        public GInventory GetInventory() => inventory;
        
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
            bool hasPlannedAction = plannedAction != null;
            bool hasPlanner = gPlanner != null;
            if (!hasPlannedAction || !hasPlanner)
            {
                gPlanner = new();
                var sortedGoals = from goals in goalHandler.GetGoals() orderby goals.Value descending select goals;
                foreach (KeyValuePair<Goal, int> sortedGoal in sortedGoals)
                {
                    plannedAction = gPlanner.FindPlan(actionHandler.GetActions(), sortedGoal.Key.goal, stateHandler);
                    if (plannedAction != null)
                    {
                        goalHandler.SetCurrentGoal(sortedGoal.Key);
                        break;
                    }
                }
            }
            if (plannedAction != null && plannedAction.Count == 0)
            {

                // Check if currentGoal is removable
                if (goalHandler.GetCurrentGoal().shouldRemoveGoal)
                {
                    // Remove it
                    goalHandler.RemoveCurrentGoal();
                }
                // Set planner = null so it will trigger a new one
                gPlanner = null;
            }

            if (plannedAction != null && plannedAction.Count > 0)
            {
                actionHandler.SetCurrentAction(plannedAction.Dequeue());
                if (actionHandler.GetCurrentAction().PreActionExecute())
                {
                    if (actionHandler.GetCurrentAction().HasTarget())
                    {
                        actionHandler.GetCurrentAction().ExecuteAction();
                    }
                }
                else
                {
                    plannedAction = null;
                }
            }
        }

    }
}

