using System;
using UnityEngine;

namespace AnotherWorldProject.FactionSystem
{
    [System.Serializable]
    public class Faction
    {
        [SerializeField]bool isEnemy = false;
        
        public bool GetIsEnemyFaction()
        {
            return isEnemy;
        }
    }
}

