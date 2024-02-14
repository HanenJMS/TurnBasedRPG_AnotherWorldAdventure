using System;


namespace AnotherWorldProject.AISystem.GOAP.GoalSystem
{
    [System.Serializable]
    public struct Goal : IEquatable<Goal>
    {
        public string goal;
        public bool shouldRemoveGoal;
        public Goal(string goal, bool shouldRemoveGoal = false)
        {
            this.goal = goal;
            this.shouldRemoveGoal = shouldRemoveGoal;
        }
        public override string ToString()
        {
            return goal;
        }
        public static bool operator ==(Goal a, Goal b)
        {
            return a.goal == b.goal;
        }
        public static bool operator !=(Goal a, Goal b)
        {
            return a.goal != b.goal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(goal, goal);
        }

        public bool Equals(Goal other)
        {
            return other == this;
        }

        public override bool Equals(object obj)
        {
            return obj is Goal goal && goal.goal == this.goal;
        }
    }
}

