using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.GridSystem;
using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit : MonoBehaviour
    {

        GridPosition gridPosition;
        //[SerializeField] Animator unitAnimator;
        MoveAction moveAction;
        float minDistance = 1f;

        private void Start()
        {
            TryGetComponent<MoveAction>(out moveAction);
            gridPosition = LevelGridSystem.Instance.GetGridPosition(this.transform.position);
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


        public MoveAction GetMoveAction()
        {
            return moveAction;
        }

    }
}

