using AnotherWorldProject.AISystem.GOAP.GoalSystem;

namespace AnotherWorldProject.AISystem.GOAP.Core.AgentTypes
{
    public class Patient : GAgent
    {
        protected override void Start()
        {
            base.Start();
            Goal goal = new Goal("isWaiting", true);
            Goal goal2 = new ("isTreated", true);
            Goal goal3 = new("goHome", true);
            agentGoals.Add(goal, 1);
            agentGoals.Add(goal3, 1);
            agentGoals.Add(goal2, 1);
            agentStates.ModifyState(new("isSick", 1));
        }
    }
}
