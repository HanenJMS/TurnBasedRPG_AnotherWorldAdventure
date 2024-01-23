using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.FactionSystem;
using AnotherWorldProject.GridSystem;
using AnotherWorldProject.HealthSystem;
using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {
        GridPosition gridPosition;
        ActionHandler actionHandler;
        FactionHandler factionHandler;
        HealthHandler healthHandler;
        UnitRagdollHandler ragdollHandler;
        float minDistance = 1f;
        private void Awake()
        {
            actionHandler = GetComponent<ActionHandler>();
            factionHandler = GetComponent<FactionHandler>();
            healthHandler = GetComponent<HealthHandler>();
            ragdollHandler = GetComponent<UnitRagdollHandler>();
        }
        private void Start()
        {
            gridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            LevelGridSystem.Instance.AddUnitAtGridPosition(gridPosition, this);
            healthHandler.onDead += UnitDied;
        }
        private void Update()
        {

            GridPosition newGridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            if (newGridPosition != gridPosition)
            {
                LevelGridSystem.Instance.ChangingUnitGridPosition(gridPosition, newGridPosition, this);
                gridPosition = newGridPosition;
            }
        }

        public FactionHandler GetFactionHandler()
        {
            return factionHandler;
        }
        public ActionHandler GetActionHandler()
        {
            return actionHandler;
        }
        public HealthHandler GetHealthHandler()
        {
            return healthHandler;
        }


        public void UnitDied()
        {
            this.gameObject.SetActive(false);
            ragdollHandler.Spawn();
        }
        private void OnDisable()
        {
            LevelGridSystem.Instance.RemoveUnitAtGridPosition(this.gridPosition, this);
        }

    }
}

