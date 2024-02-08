namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Patient : GAgent
    {
        protected override void Start()
        {
            base.Start();
            GAgentGoal goal = new GAgentGoal("isWaiting", true);
            GAgentGoal goal2 = new ("isTreated", true);
            GAgentGoal goal3 = new("goHome", true);
            agentGoals.Add(goal, 1);
            agentGoals.Add(goal3, 1);
            agentGoals.Add(goal2, 1);
            agentStates.ModifyState(new("isSick", 1));
        }
    }
}
