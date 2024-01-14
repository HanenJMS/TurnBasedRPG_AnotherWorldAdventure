using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnotherWorldProject.FactionSystem
{
    public class FactionHandler : MonoBehaviour
    {
        [SerializeField]Faction currentFaction;

        public bool IsEnemyFaction()
        {
            return currentFaction.GetIsEnemyFaction();
        }
    }
}

