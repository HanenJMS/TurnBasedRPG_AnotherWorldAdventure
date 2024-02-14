
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GetPatient : GAction
    {
        GameObject TreatmentRoom;
        public override bool PreActionExecute()
        {
            GetTargetAgent(this.gameObject).GetGoals()[new("getPatient")] = GetWorldGameStates().GetStates()["PatientWaiting"];
            target = GetWorldItem("PatientWaiting");
            if (target == null) return false;
            TreatmentRoom = GetWorldItem("TreatmentRoom");
            if (TreatmentRoom == null)
            {
                GetWorldInventory().AddItem("PatientWaiting", target);
                target = null;
                return false;
            }
            inventory.AddItem("TreatmentRoom", TreatmentRoom);
            GetWorldGameStates().ModifyState(new("TreatmentRoom", -1));
            return true;
        }

        public override bool PostActionExecute()
        {
            TreatmentRoom = inventory.GetItem("TreatmentRoom");
            GAgent target = GetTargetAgent(this.target);
            target.GetAgentStates().ModifyState(new("GoToTreatmentRoom", 1));
            target.GetGoals().Add(new("GettingTreated"), 1);
            target.GetInventory().AddItem("TreatmentRoom", TreatmentRoom);

            return true;
        }
    }
}

