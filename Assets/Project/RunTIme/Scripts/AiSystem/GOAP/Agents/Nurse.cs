using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();

            GAgentGoal goal = new GAgentGoal("getPatient", 1, false);
            GAgentGoal goal2 = new GAgentGoal("treatPatient", 1, false);
            GAgentGoal goal3 = new("rested", 1, false);
            agentGoals.Add(goal, 1);
            agentGoals.Add(goal2, 3);
            agentGoals.Add(goal3, 1);
            Invoke("GetTired", Random.Range(10, 20));
        }

        void GetTired()
        {
            agentStates.ModifyState(new("isTired", 1));

            Invoke("GetTired", Random.Range(5, 10));
        }
    }
}
