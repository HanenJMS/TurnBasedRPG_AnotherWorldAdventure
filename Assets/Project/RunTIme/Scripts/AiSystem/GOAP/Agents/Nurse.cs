namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Nurse : GAgent
    {
        protected override void Start()
        {
            base.Start();

            GAgentGoal goal = new GAgentGoal("getPatient", 1, false);
            GAgentGoal goal2 = new GAgentGoal("treatPatient", 1, false);
            agentGoals.Add(goal, 1);
            agentGoals.Add(goal2, 1);
        }
    }
}
