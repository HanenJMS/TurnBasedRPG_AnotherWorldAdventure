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
        RangedAction shootingAction;


        float patrolRadius = 10f;



        private void Awake()
        {
            aiUnit = GetComponent<Unit>();
            movingAction = GetComponent<MoveAction>();
            shootingAction = GetComponent<RangedAction>();
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

