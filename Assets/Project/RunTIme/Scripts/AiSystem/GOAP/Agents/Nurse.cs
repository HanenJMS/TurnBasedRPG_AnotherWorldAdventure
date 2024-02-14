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
            agentGoals.Add(goal, 0);
            agentGoals.Add(goal2, 0);
            agentGoals.Add(goal3, 0);
            Invoke("GetTired", Random.Range(10, 20));
        }

        void GetTired()
        {
            agentStates.ModifyState(new("isTired", 1));
            agentGoals[new("rested", false)] = agentStates.GetStates()["isTired"];
            Invoke("GetTired", Random.Range(2, 5));
        }
    }
}
