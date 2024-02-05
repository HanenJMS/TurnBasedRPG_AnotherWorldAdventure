using System.Collections.Generic;


namespace AnotherWorldProject.AISystem.GOAP.Core
{
    [System.Serializable]
    public struct GAgentGoal
    {
        public Dictionary<string, int> goalState;
        public bool shouldRemoveGoal;
        public GAgentGoal(string goal, int priority, bool shouldRemoveGoal)
        {
            goalState = new();
            goalState.Add(goal, priority);
            this.shouldRemoveGoal = shouldRemoveGoal;
        }


    }
}

