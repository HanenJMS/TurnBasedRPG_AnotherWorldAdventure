namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GoToHospital : GAction
    {
        public override bool PreActionExecute()
        {
            if (agentStates.ContainsState(new("atHospital", 1))) return false;
            target = GetWorldLocation("Hospital").GetEntrance().gameObject;
            if (target == null) return false;
            return true;
        }
        public override bool PostActionExecute()
        {
            agentStates.ModifyState(new("notRegistered", 1));
            inventory.AddItem("atLocation", target.gameObject.GetComponentInParent<GLocation>().gameObject);
            return true;
        }


    }
}
