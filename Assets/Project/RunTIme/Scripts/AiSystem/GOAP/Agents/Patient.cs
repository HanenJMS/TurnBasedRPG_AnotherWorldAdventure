using AnotherWorldProject.AISystem.GOAP.GoalSystem;

namespace AnotherWorldProject.AISystem.GOAP
{
    public class Patient : GAgent
    {
        protected override void Start()
        {
            base.Start();
            Goal goal = new Goal("isWaiting", true);
            Goal goal2 = new ("isTreated", true);
            Goal goal3 = new("goHome", true);
            GetGoalHandler().GetGoals().Add(goal, 1);
            GetGoalHandler().GetGoals().Add(goal3, 1);
            GetGoalHandler().GetGoals().Add(goal2, 1);
            GetStateHandler().ModifyState(new("isSick", 1));
        }
    }
}
