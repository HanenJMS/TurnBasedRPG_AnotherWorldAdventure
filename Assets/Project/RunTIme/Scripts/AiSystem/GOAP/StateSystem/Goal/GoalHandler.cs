using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;
namespace AnotherWorldProject.AISystem.GOAP.GoalSystem
{
    public class GoalHandler : MonoBehaviour
    {
        Goal currentAgentGoal;
        Dictionary<Goal, int> goals = new();
        public Goal GetCurrentGoal()
        {
            return currentAgentGoal;
        }
       
        public void ModifyGoal(Goal goal, int priority)
        {
            if (goals.ContainsKey(goal))
            {
                goals[goal] += priority;
                if (goals[goal] <= 0)
                {
                    RemoveGoal(goal);
                }
                return;
            }
            AddGoal(goal, priority);
        }
        void AddGoal(Goal goal, int priority)
        {
            goals.Add(goal, priority);
        }
        void RemoveGoal(Goal goal)
        {
            if (!goals.ContainsKey(goal)) return;
            goals.Remove(goal);
        }
    }
}

