
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToRest : GAction
    {
        public override bool PreActionExecute()
        {
            target = GetWorldLocation("RestingRoom").gameObject;
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("isTired", -1));
            if (agentStates.GetStates().ContainsKey("isTired"))
            {
                if(GetTargetAgent(this.gameObject).
                GetGoalHandler().GetGoals()[new("rested")] < agentStates.GetStates()["isTired"])
                {
                    GetTargetAgent(this.gameObject).
                    GetGoalHandler().GetGoals()[new("rested")] = agentStates.GetStates()["isTired"];
                }
                if (agentStates.GetStates()["isTired"] == 0)
                {
                    GetTargetAgent(this.gameObject).
                    GetGoalHandler().GetGoals()[new("rested")] = agentStates.GetStates()["isTired"];
                }
            }
            
            return true;
        }

    }
}

