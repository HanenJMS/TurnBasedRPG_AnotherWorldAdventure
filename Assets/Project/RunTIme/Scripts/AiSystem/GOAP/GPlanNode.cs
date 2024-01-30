using System.Collections.Generic;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GPlanNode

    {
        GPlanNode parent;
        float cost;
        Dictionary<string, int> states;
        GAction nodeAction;

        public GPlanNode(GPlanNode parent, float cost, Dictionary<string, int> states, GAction nodeAction)
        {
            this.parent = parent;
            this.cost = cost;
            this.states = states;
            this.nodeAction = nodeAction;
        }

        public GPlanNode GetParentNode()
        {
            return parent;
        }
        public float GetCost()
        {
            return cost;
        }
        public GAction GetAction() { return nodeAction; }
        public Dictionary<string, int> GetPlanState()
        {
            return states;
        }
    }
}

