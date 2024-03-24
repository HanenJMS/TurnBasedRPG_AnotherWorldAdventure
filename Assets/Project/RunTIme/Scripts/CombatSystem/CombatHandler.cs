using AnotherWorldProject.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.CombatSystem
{
    public class CombatHandler : MonoBehaviour
    {
        HealthHandler healthHandler;
        private void Awake()
        {
            healthHandler = GetComponent<HealthHandler>();
        }

        void TakeDamage(DamageDefinition damage)
        {
            //healthHandler.RemoveFromCurrentHealth(damage);
        }

    }
}

