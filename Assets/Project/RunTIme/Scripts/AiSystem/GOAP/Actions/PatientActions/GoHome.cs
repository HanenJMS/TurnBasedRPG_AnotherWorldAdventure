namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoHome : GAction
    {
        public override bool PreActionExecute()
        {
            if (!agentStates.ContainsState(new("isTreated", 1))) return false;
            target = GetWorldLocation("Home").gameObject;
            if (target == null) return false;
            GetWorldGameStates().ModifyState(new("TreatmentRoom", 1));
            GetWorldInventory().AddItem("TreatmentRoom", inventory.GetItem("TreatmentRoom"));
            return true;
        }
        public override bool PostActionExecute()
        {
            GetWorldGameStates().ModifyState(new("GoneHome", 1));
            Destroy(this.gameObject);
            return true;
        }


    }
}
