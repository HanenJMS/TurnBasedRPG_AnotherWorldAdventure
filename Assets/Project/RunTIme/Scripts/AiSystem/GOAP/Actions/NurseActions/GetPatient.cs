
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GetPatient : GAction
    {
        GameObject TreatmentRoom;
        public override bool PreActionExecute()
        {
            if (!agentStates.ContainsState(new("atWork", 1))) return false;
            GetTargetAgent(this.gameObject).GetGoalHandler().GetGoals()[new("getPatient")] = inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetStateHandler().GetStates()["PatientWaiting"];
            target = inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetInventory().GetItem("PatientWaiting");
            if (target == null) return false;
            //TreatmentRoom = inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetInventory().GetItem("TreatmentRoom");
            //if (TreatmentRoom == null)
            //{
            //    inventory.GetItem("WorkLocation").GetComponent<GLocation>().GetInventory().AddItem("PatientWaiting", target);
            //    target = null;
            //    return false;
            //}
            //inventory.AddItem("TreatmentRoom", TreatmentRoom);
            //GetWorldGameStates().ModifyState(new("TreatmentRoom", -1));
            return true;
        }

        public override bool PostActionExecute()
        {
            //TreatmentRoom = inventory.GetItem("TreatmentRoom");
            //GAgent target = GetTargetAgent(this.target);
            //target.GetStateHandler().ModifyState(new("GoToTreatmentRoom", 1));
            //target.GetGoalHandler().GetGoals().Add(new("GettingTreated"), 1);
            //target.GetInventory().AddItem("TreatmentRoom", TreatmentRoom);

            return true;
        }
    }
}

