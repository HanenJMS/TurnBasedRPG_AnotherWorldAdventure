using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.GoalSystem
{
    public class GoalHandler : MonoBehaviour
    {
        Goal currentGoal;
        Dictionary<Goal, int> goals = new();
        GLocation goalLocation;
        public void SetGoalLocation(GLocation location)
        {
            this.goalLocation = location;
        }
        public GLocation GetGoalLocation()
        {
            return goalLocation;
        }
        public Dictionary<string, int> GetGoalLocationStates()
        {
            if(goalLocation != null)
            {
                return goalLocation.GetStateHandler().GetStates();
            }
            return null;
        }
        public void SetCurrentGoal(Goal goal)
        {
            currentGoal = goal;
        }
        public Goal GetCurrentGoal()
        {
            return currentGoal;
        }
        public void RemoveCurrentGoal()
        {
            goals.Remove(currentGoal);
        }


        public Dictionary<Goal, int> GetGoals() => goals;
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
        public void SetGoalPriority(Goal goal, int priority)
        {
            if (!goals.ContainsKey(goal)) return;
            goals[goal] = priority;
        }
        public void AddGoal(Goal goal, int priority)
        {
            goals.Add(goal, priority);
        }
        public void RemoveGoal(Goal goal)
        {
            if (!goals.ContainsKey(goal)) return;
            goals.Remove(goal);
        }



    }
}

