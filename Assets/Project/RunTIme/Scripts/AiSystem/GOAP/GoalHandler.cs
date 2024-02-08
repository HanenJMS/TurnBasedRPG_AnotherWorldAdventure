using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoalHandler : MonoBehaviour
    {
        GAgentGoal currentAgentGoal;
        Dictionary<GAgentGoal, int> goals = new();
        public GAgentGoal GetCurrentGoal()
        {
            return currentAgentGoal;
        }
        

         int GetGoalPriority(string goal)
        {
            return goals[new(goal)];
        }
    }
}

