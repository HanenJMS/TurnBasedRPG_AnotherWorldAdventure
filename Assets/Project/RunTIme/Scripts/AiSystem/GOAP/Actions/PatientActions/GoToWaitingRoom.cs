namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToWaitingRoom : GAction
    {



        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("PatientWaiting", 1))) return false;
            target = GetWorldLocation("WaitingRoom");
            if(target == null) return false;
            return true;
        }
        public override bool PostActionExecute()
        {

            agentStates.ModifyState(new("PatientWaiting", 1));
            GetWorldGameStates().ModifyState(new("PatientWaiting", 1));
            GetWorldInventory().AddInventoryItem("PatientWaiting", this.gameObject);
            return true;
        }
    }
}

