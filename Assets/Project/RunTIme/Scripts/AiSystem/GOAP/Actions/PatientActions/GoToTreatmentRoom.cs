namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToTreatmentRoom : GAction
    {
        public override bool PreActionExecute()
        {
            target = inventory.GetInventoryItem("TreatmentRoom");
            if (target == null) return false;
            GetWorldGameStates().ModifyState(new("PatientWaiting", -1));
            return true;
        }
        public override bool PostActionExecute()
        {
            GetWorldGameStates().ModifyState(new("PatientWaitingForTreatment", 1));
            GetWorldInventory().AddInventoryItem("PatientWaitingForTreatment", this.gameObject);

            agentStates.ModifyState(new("GoToTreatmentRoom", -1));
            inventory.AddInventoryItem("TreatmentRoom", target);
            return true;
        }
    }
}

