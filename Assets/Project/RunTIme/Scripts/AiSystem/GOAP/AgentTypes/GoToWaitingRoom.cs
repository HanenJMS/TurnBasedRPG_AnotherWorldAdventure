using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToWaitingRoom : GAction
    {
        
        public override bool PostActionExecute()
        {
            return true;
        }

        public override bool PreActionExecute()
        {
            return true;
        }
    }
}

