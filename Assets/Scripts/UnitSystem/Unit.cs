using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.GridSystem;
using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {

        GridPosition gridPosition;
        ActionHandler actionHandler;
        MoveAction moveAction;
        float minDistance = 1f;
        private void Awake()
        {
            actionHandler = GetComponent<ActionHandler>();
        }
        private void Start()
        {
            TryGetComponent<MoveAction>(out moveAction);
            gridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
            LevelGridSystem.Instance.AddUnitAtGridPosition(gridPosition, this);
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

        public ActionHandler GetActionHandler()
        {
            return actionHandler;
        }
        public MoveAction GetMoveAction()
        {
            return moveAction;
        }

    }
}

