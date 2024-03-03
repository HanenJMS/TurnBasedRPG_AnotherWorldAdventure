using AnotherWorldProject.AISystem.GOAP.Core.AgentTypes;
using System;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToWork : GAction
    {
        [SerializeField] string workLocation;
        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("atWork", 1))) return false;
            target = GetWorldLocation(workLocation).gameObject;
                
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("atWork", 50));
            agentStates.ModifyState(new("goToWork", -1));
            inventory.AddItem("WorkLocation", target);
            GetTargetAgent(this.gameObject).GetGoalHandler().SetGoalLocation(GetTargetGLocation(target));
            return true;
        }
    }
}

