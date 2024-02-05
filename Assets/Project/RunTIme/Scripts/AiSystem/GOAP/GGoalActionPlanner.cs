using System;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{

    //plan node takes parent, float, dictionary, and action)
    public class GGoalActionPlanner
    {
        public Queue<GAction> FindPlan(List<GAction> actions, Dictionary<string, int> goal, GWorldStates agentStates)
        {
            Queue<GAction> actionPlanSequence = new();
            Node planStart = new(null, 0, GWorld.Instance.GetGWorldWorldStates().GetStates(), null, agentStates.GetStates());
            List<Node> planList = new();
            List<GAction> usableActions = GetUsableActionList(actions);

            if (!IsPlanFound(planStart, planList, usableActions, goal))
            {
                Debug.Log("No plan found");
                return null;
            }
            Node lowestCostPlan = GetLowestCostPlan(planList);
            actionPlanSequence = GetActionSequence(lowestCostPlan);
            Debug.Log("Plan: ");
            foreach(GAction action in actionPlanSequence)
            {
                Debug.Log(action.name);
            }
            return actionPlanSequence;
        }

        private Queue<GAction> GetActionSequence(Node lowestCostPlan)
        {
            Queue<GAction> actionPlanSequence = new();
            List<GAction> result = new();
            while (lowestCostPlan != null)
            {
                if(lowestCostPlan.GetAction() != null)
                {
                    result.Insert(0, lowestCostPlan.GetAction());
                }
                lowestCostPlan = lowestCostPlan.GetParentNode();
            }
            foreach(GAction action in result)
            {
                actionPlanSequence.Enqueue(action);
            }
            return actionPlanSequence;
        }

        bool IsPlanFound(Node parent, List<Node> plans, List<GAction> usableActions, Dictionary<string, int> goal)
        {
            bool pathFound = false;
            if (usableActions.Count == 0) return false;
            foreach(GAction action in usableActions)
            {
                if (!action.IsAchieveableGiven(parent.GetPlanState())) continue;
                Dictionary<string, int> actionResultState = GetResultingConditions(parent, action);

                Node node = new(parent, parent.GetCost() + action.GetActionCost(), actionResultState, action);
                if (IsGoalAchieved(goal, actionResultState))
                {
                    plans.Add(node);
                    pathFound = true;
                }
                else
                {
                    List<GAction> actionSubsets = GetActionSubset(usableActions, action);
                    if (IsPlanFound(node, plans, actionSubsets, goal)) pathFound = true;
                }
            }
            return pathFound;
        }

        Dictionary<string, int> GetResultingConditions(Node parent, GAction action)
        {
            Dictionary<string, int> currentPlanStates = new(parent.GetPlanState());
            foreach (KeyValuePair<string, int> state in action.GetResultConditions())
            {
                if (currentPlanStates.ContainsKey(state.Key)) continue;
                currentPlanStates.Add(state.Key, state.Value);
            }

            return currentPlanStates;
        }

        List<GAction> GetActionSubset(List<GAction> actions, GAction removingAction)
        {
            List<GAction> actionsList = new(actions);
            if (actionsList.Contains(removingAction)) actionsList.Remove(removingAction);
                
            return actionsList;
        }
        bool IsGoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
        {
            foreach(KeyValuePair<string, int> g in goal)
            {
                if (!state.ContainsKey(g.Key))
                    return false;
            }
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
        List<GAction> GetUsableActionList(List<GAction> actions)
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

