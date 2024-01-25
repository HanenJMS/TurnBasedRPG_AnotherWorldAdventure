using AnotherWorldProject.ActionSystem;
using AnotherWorldProject.AISystem;
using UnityEngine;
namespace AnotherWorldProject.UnitSystem
{
    public class Unit_MonsterAI : MonoBehaviour
    {
        Unit aiUnit;
        Unit targetUnit;
        MoveAction movingAction;
        ShootAction shootingAction;
        AIHandler aiHandler;


        AIStateMachine aiStateMachine;
        float patrolRadius = 10f;



        private void Awake()
        {
            aiUnit = GetComponent<Unit>();
            movingAction = GetComponent<MoveAction>();
            shootingAction = GetComponent<ShootAction>();
            aiHandler = GetComponent<AIHandler>();
        }

        private void Update()
        {
        }

        void Guard()
        {
            
        }
        void Patrol()
        {

        }
        void Attack()
        {

        }
    }
}

