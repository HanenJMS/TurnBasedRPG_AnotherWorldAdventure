using AnotherWorldProject.UnitSystem;

namespace AnotherWorldProject.CombatSystem
{
    [System.Serializable]
    public class DamageDefinition
    {
        Unit Sender;
        Unit Target;

        int damageOnHit;
    }
}

