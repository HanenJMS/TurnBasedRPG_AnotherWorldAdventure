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

        GActionHandler actionHandler;
        GoalHandler goalHandler;
        GWorldStateHandler stateHandler = new();
        protected virtual void Start()
        {
            actionHandler = GetComponent<GActionHandler>();
            goalHandler = GetComponent<GoalHandler>();
        }

        public GActionHandler GetActionHandler()
        {
            return actionHandler;
        }

        public GoalHandler GetGoalHandler()
        {
            return goalHandler;
        }

        public GWorldStateHandler GetStateHandler()
        {
            return stateHandler;
        }

        public GInventory GetInventory()
        {
            return inventory;
        }

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
            
            bool hasPlanner = gPlanner != null;
            if (!hasPlanner) gPlanner = new(goalHandler, actionHandler, stateHandler);

            gPlanner.TrySolveGoal();
           
            if (actionHandler.HasPlannedActionsFinished())
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

            if (actionHandler.HasPlannedActionsNotFinished())
            {
                actionHandler.StartNextPlannedAction();
                actionHandler.HandleCurrentAction();
            }
        }

    }
}

