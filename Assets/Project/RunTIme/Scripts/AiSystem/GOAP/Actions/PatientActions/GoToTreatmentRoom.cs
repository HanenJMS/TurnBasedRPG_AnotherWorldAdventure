namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToTreatmentRoom : GAction
    {
        public override bool PreActionExecute()
        {
            target = inventory.GetItem("TreatmentRoom");
            if (target == null) return false;
            target.GetComponent<GLocation>().GetStates().ModifyState(new("PatientWaiting", -1));
            target.GetComponent<GLocation>().GetInventory().RemoveItem("PatientWaiting", this.gameObject);
            return true;
        }
        public override bool PostActionExecute()
        {
            inventory.RemoveItem("TreatmentRoom", target);
            target.GetComponent<GLocation>().GetStates().ModifyState(new("PatientWaitingForTreatment", 1));
            target.GetComponent<GLocation>().GetInventory().AddItem("PatientWaitingForTreatment", this.gameObject);

            agentStates.ModifyState(new("GoToTreatmentRoom", -1));
            inventory.AddItem("TreatmentRoom", target);
            return true;
        }
    }
}

