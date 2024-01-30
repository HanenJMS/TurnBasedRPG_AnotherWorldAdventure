using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GGoalHandler : MonoBehaviour
    {
        GAgentGoal currentAgentGoal;
        Dictionary<GAgentGoal, int> goals = new();
        public GAgentGoal GetCurrentGoal()
        {
            return currentAgentGoal;
        }
        public void SetCurrentGoal(GAgentGoal newGoal)
        {
            currentAgentGoal = newGoal;
        }

        public void AddGoal(GAgentGoal goal, int priority) 
        {
            goals.Add(goal, priority);
        }
    }
}

