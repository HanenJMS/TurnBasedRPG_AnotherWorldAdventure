using System;


namespace AnotherWorldProject.AISystem.GOAP.Core
{
    [System.Serializable]
    public struct GAgentGoal : IEquatable<GAgentGoal>
    {
        public string goal;
        public bool shouldRemoveGoal;
        public GAgentGoal(string goal, bool shouldRemoveGoal = false)
        {
            this.goal = goal;
            this.shouldRemoveGoal = shouldRemoveGoal;
        }
        public override string ToString()
        {
            return goal;
        }
        public static bool operator ==(GAgentGoal a, GAgentGoal b)
        {
            return a.goal == b.goal;
        }
        public static bool operator !=(GAgentGoal a, GAgentGoal b)
        {
            return a.goal != b.goal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(goal, goal);
        }

        public bool Equals(GAgentGoal other)
        {
            return other == this;
        }

        public override bool Equals(object obj)
        {
            return obj is GAgentGoal goal && goal.goal == this.goal;
        }
    }
}

