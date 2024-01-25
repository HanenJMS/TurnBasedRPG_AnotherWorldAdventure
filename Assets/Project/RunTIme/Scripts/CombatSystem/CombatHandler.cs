using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.CombatSystem
{
    public class CombatHandler : MonoBehaviour
    {
        public Action onDamageTaken;

        Queue<DamageDefinition> damageTakenQueue = new();
        void AddDamageDefinition(DamageDefinition damage)
        {
            damageTakenQueue.Enqueue(damage);
        }
    }
}

