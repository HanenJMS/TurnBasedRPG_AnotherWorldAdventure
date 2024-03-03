
using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using AnotherWorldProject.AISystem.GOAP.StateSystem;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
namespace AnotherWorldProject.AISystem.GOAP
{

    //plan node takes parent, float, dictionary, and action)
    public class GPlanner
    {
        Queue<GAction> actionsPlanned;
        GoalHandler goalHandler;
        GActionHandler actionHandler;
        GWorldStateHandler stateHandler;
        public GPlanner(GoalHandler goalHandler, GActionHandler actionHandler, GWorldStateHandler stateHandler)
        {
            this.goalHandler = goalHandler;
            this.actionHandler = actionHandler;
            this.stateHandler = stateHandler;
        }
        public void HandlePlan()
        {
            throw new NotImplementedException();
        }
        public void TrySolveGoal()
        {
            bool hasPlannedAction = actionHandler.GetPlannedActions() != null;
            if (!hasPlannedAction)
            {
                var sortedGoals = from goals in goalHandler.GetGoals() orderby goals.Value descending select goals;
                foreach (KeyValuePair<Goal, int> sortedGoal in sortedGoals)
                {
                    actionHandler.SetPlannedActions(FindPlan(actionHandler.GetActions(), goalHandler.GetGoalLocationStates(), sortedGoal.Key.goal, stateHandler));
                    if (actionHandler.GetPlannedActions() != null)
                    {
                        goalHandler.SetCurrentGoal(sortedGoal.Key);
                        break;
                    }
                }
            }
        }
        public bool isActionPlannedActive()
        {
            return actionsPlanned != null;
        }
        public Queue<GAction> FindPlan(List<GAction> actions,Dictionary<string, int> WorldStates, string goal, GWorldStateHandler agentStates)
        {
            if(WorldStates == null)
            {
                WorldStates = GWorld.Instance.GetGWorldWorldStates().GetStates();
            }
            Node planStart = new(null, 0, WorldStates, null, agentStates.GetStates());
            List<Node> potentialPlan = new();
            List<GAction> potentialActions = GetPotentialActions(actions);

            if (!IsPlanFound(planStart, potentialPlan, potentialActions, goal))
            {
                Debug.Log("No plan found");
                return null;
            }
            Node lowestCostPlan = GetLowestCostPlan(potentialPlan);
            actionsPlanned = GetActionsPlanned(lowestCostPlan);
            return actionsPlanned;
        }

        private Queue<GAction> GetActionsPlanned(Node lowestCostPlan)
        {
            Queue<GAction> actionPlanned = new();
            List<GAction> result = new();
            while (lowestCostPlan != null)
            {
                if (lowestCostPlan.GetAction() != null)
                {
                    result.Insert(0, lowestCostPlan.GetAction());
                }
                lowestCostPlan = lowestCostPlan.GetParentNode();
            }
            foreach (GAction action in result)
            {
                actionPlanned.Enqueue(action);
            }
            return actionPlanned;
        }

        bool IsPlanFound(Node parent, List<Node> plans, List<GAction> potentialActions, string goal)
        {
            bool pathFound = false;
            if (potentialActions.Count == 0) return false;
            foreach (GAction action in potentialActions)
            {
                if (!action.IsAchieveableGiven(parent.GetStates())) continue;
                Dictionary<string, int> potentialWorldState = GetPotentialWorldState(parent, action);

                Node node = new(parent, parent.GetCost() + action.GetActionCost(), potentialWorldState, action);
                if (IsGoalAchieved(goal, potentialWorldState))
                {
                    plans.Add(node);
                    pathFound = true;
                }
                else
                {
                    List<GAction> remainingActions = GetRemainingPotentialAction(potentialActions, action);
                    if (IsPlanFound(node, plans, remainingActions, goal)) pathFound = true;
                }
            }
            return pathFound;
        }

        Dictionary<string, int> GetPotentialWorldState(Node parent, GAction action)
        {
            Dictionary<string, int> currentStateIntermediate = new(parent.GetStates());
            foreach (KeyValuePair<string, int> state in action.GetActionOutConditions())
            {
                if (currentStateIntermediate.ContainsKey(state.Key)) continue;
                currentStateIntermediate.Add(state.Key, state.Value);
            }

            return currentStateIntermediate;
        }

        List<GAction> GetRemainingPotentialAction(List<GAction> actions, GAction removingAction)
        {
            List<GAction> actionsList = new(actions);
            if (actionsList.Contains(removingAction)) actionsList.Remove(removingAction);

            return actionsList;
        }
        bool IsGoalAchieved(string goal, Dictionary<string, int> state)
        {
            if (!state.ContainsKey(goal)) return false;
            
            return true;
        }
        Node GetLowestCostPlan(List<Node> plan)
        {
            Node lowest = null;
            if (plan.Count > 0) lowest = plan[0];
            foreach (Node node in plan)
            {
                if (node.GetCost() < lowest.GetCost())
                {
                    lowest = node;
                }
            }
            return lowest;
        }
        List<GAction> GetPotentialActions(List<GAction> actions)
        {
            List<GAction> usableActions = new();
            foreach (GAction action in actions)
            {
                if (action.IsAchievable())
                {
                    usableActions.Add(action);
                }
            }
            return usableActions;
        }


    }
}

