
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
            return true;
        }

    }
}

