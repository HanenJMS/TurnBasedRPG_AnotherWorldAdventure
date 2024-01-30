using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


namespace AnotherWorldProject.AISystem.GOAP.Core
{
    [System.Serializable]
    public class GAgentGoal
    {
        public Dictionary<string, int> goalState;
        public string goal;
        public int qty;
        public bool shouldRemoveGoal;
        public GAgentGoal(string goal, int qty,  bool shouldRemoveGoal)
        {
            this.goal = goal;
            this.qty = qty;
            this.shouldRemoveGoal = shouldRemoveGoal;
        }


    }
}

