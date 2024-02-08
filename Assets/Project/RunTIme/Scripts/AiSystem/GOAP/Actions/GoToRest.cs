
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToRest : GAction
    {
        public override bool PreActionExecute()
        {
            target = GetWorldLocation("RestingRoom");
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("isTired", -1));
            if (agentStates.GetStates().ContainsKey("isTired"))
            {
                GetTargetAgent(this.gameObject).
                GetGoals()[new("rested")] = agentStates.GetStates()["isTired"];
            }
            
            return true;
        }

    }
}

