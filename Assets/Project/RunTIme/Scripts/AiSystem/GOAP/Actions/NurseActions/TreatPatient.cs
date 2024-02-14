namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class TreatPatient : GAction
    {
        public override bool PreActionExecute()
        {
            GAgent nurse = GetTargetAgent(this.gameObject);

            nurse.GetGoalHandler().GetGoals()[new("treatPatient")] = GetWorldGameStates().GetStates()["PatientWaitingForTreatment"];
            target = GetWorldItem("PatientWaitingForTreatment");
            if (target == null) return false;
            return true;
        }

        public override bool PostActionExecute()
        {
            GetWorldGameStates().ModifyState(new("PatientWaitingForTreatment", -1));
            GAgent target = GetTargetAgent(this.target);
            target.GetStateHandler().ModifyState(new("isSick", -1));
            target.GetStateHandler().ModifyState(new("isTreated", 1));
            return true;
        }
    }
}

