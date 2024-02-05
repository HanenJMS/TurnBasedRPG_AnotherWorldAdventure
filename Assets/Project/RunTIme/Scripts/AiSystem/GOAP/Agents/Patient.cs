namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Patient : GAgent
    {
        protected override void Start()
        {
            base.Start();
            GAgentGoal goal = new GAgentGoal("isWaiting", 1, true);
            GAgentGoal goal2 = new ("isTreated", 1, true);
            GAgentGoal goal3 = new("goHome", 1, true);
            agentGoals.Add(goal, 1);
            agentGoals.Add(goal3, 1);
            agentGoals.Add(goal2, 1);
            agentStates.ModifyState(new("isSick", 1));
        }
    }
}
