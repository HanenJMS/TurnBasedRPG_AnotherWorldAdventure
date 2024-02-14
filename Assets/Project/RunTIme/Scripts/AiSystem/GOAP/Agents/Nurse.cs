using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();

            Goal goal = new Goal("getPatient", false);
            Goal goal2 = new Goal("treatPatient", false);
            Goal goal3 = new("rested", false);
            GetGoalHandler().GetGoals().Add(goal, 0);
            GetGoalHandler().GetGoals().Add(goal2, 0);
            GetGoalHandler().GetGoals().Add(goal3, 0);
            Invoke("GetTired", Random.Range(10, 20));
        }

        void GetTired()
        {
            GetStateHandler().ModifyState(new("isTired", 1));
            GetGoalHandler().GetGoals()[new("rested", false)] = GetStateHandler().GetStates()["isTired"];
            Invoke("GetTired", Random.Range(2, 5));
        }
    }
}
