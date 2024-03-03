using System.Collections.Generic;

namespace AnotherWorldProject.AISystem.GOAP
{
    public class Node

    {
        Node parent;
        float cost;
        Dictionary<string, int> states;
        GAction nodeAction;

        public Node(Node parent, float cost, Dictionary<string, int> states, GAction nodeAction)
        {
            this.parent = parent;
            this.cost = cost;
            this.states = new(states);
            this.nodeAction = nodeAction;
        }
        public Node(Node parent, float cost, Dictionary<string, int> states, GAction nodeAction, Dictionary<string, int> agentStates)
        {
            this.parent = parent;
            this.cost = cost;
            this.states = new(states);
            foreach(KeyValuePair<string,int> agentState in agentStates)
            {
                if(!this.states.ContainsKey(agentState.Key))
                {
                    this.states.Add(agentState.Key, agentState.Value);
                }
            }
            this.nodeAction = nodeAction;
        }

        public Node GetParentNode()
        {
            return parent;
        }
        public float GetCost()
        {
            return cost;
        }
        public GAction GetAction() { return nodeAction; }
        public Dictionary<string, int> GetStates()
        {
            return states;
        }
    }
}

