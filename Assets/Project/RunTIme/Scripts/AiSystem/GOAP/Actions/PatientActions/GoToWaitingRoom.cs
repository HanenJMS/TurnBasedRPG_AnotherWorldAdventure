namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToWaitingRoom : GAction
    {



        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("PatientWaiting", 1))) return false;
            target = inventory.
                GetItem("atLocation").gameObject.
                GetComponent<GLocation>().
                GetInventory().
                GetItem("WaitingRoom");
            if(target == null) return false;
            return true;
        }
        public override bool PostActionExecute()
        {

            agentStates.ModifyState(new("PatientWaiting", 1));
            inventory.
                GetItem("atLocation").gameObject.
                GetComponent<GLocation>().
                GetStateHandler().
                ModifyState(new("JobWaiting", 1));
            inventory.
                GetItem("atLocation").gameObject.
                GetComponent<GLocation>().
                GetInventory().AddItem("JobWaiting", this.gameObject);
            return true;
        }
    }
}

