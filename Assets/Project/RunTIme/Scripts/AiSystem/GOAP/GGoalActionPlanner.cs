using System;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{

    //plan node takes parent, float, dictionary, and action)
    public class GGoalActionPlanner
    {
        public Queue<GAction> FindPlan(List<GAction> actions, Dictionary<string, int> goal, GWorldStates states)
        {
            Queue<GAction> actionPlanSequence = new();
            GPlanNode planStart = new(null, 0, GWorld.Instance.GetWorld().GetStates(), null);
            List<GPlanNode> planList = new();
            List<GAction> usableActions = GetUsableActionList(actions);

            if (!BuildPlan(planStart, planList, usableActions, goal))
            {
                Debug.Log("No plan found");
                return null;
            }
            GPlanNode lowestCostPlan = GetLowestCostPlan(planList);
            actionPlanSequence = GetActionSequence(lowestCostPlan);
            Debug.Log("Plan: ");
            foreach(GAction action in actionPlanSequence)
            {
                Debug.Log(action.name + "\n");
            }
            return actionPlanSequence;
        }

        private Queue<GAction> GetActionSequence(GPlanNode lowestCostPlan)
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

        bool BuildPlan(GPlanNode parent, List<GPlanNode> plans, List<GAction> usableActions, Dictionary<string, int> goal)
        {
            bool pathFound = false;
            if (usableActions.Count == 0) return false;
            foreach(GAction action in usableActions)
            {
                if (!action.IsPreConditionsMet(parent.GetPlanState())) continue;
                Dictionary<string, int> actionResultState = GetPlanActionResultState(parent, action);

                GPlanNode node = new(parent, parent.GetCost() + action.GetActionCost(), actionResultState, action);
                if (IsPlanAchieved(goal, actionResultState))
                {
                    plans.Add(node);
                    pathFound = true;
                }
                else
                {
                    List<GAction> actionSubsets = GetActionSubset(usableActions, action);
                    if (BuildPlan(node, plans, actionSubsets, goal)) pathFound = true;
                }
            }
            return pathFound;
        }

        Dictionary<string, int> GetPlanActionResultState(GPlanNode parent, GAction action)
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
        bool IsPlanAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
        {
            foreach(KeyValuePair<string, int> g in goal)
            {
                if (!state.ContainsKey(g.Key))
                    return false;
            }
            return true;
        }
        GPlanNode GetLowestCostPlan(List<GPlanNode> plan)
        {
            GPlanNode lowest = null;
            if (plan.Count > 0) lowest = plan[0];
            foreach (GPlanNode node in plan)
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

