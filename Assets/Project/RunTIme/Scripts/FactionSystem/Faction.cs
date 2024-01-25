using System;
using UnityEngine;

namespace AnotherWorldProject.FactionSystem
{
    [System.Serializable]
    public class Faction
    {
        [SerializeField] string factionName = "";
        
        public string GetFaction()
        {
            return factionName;
        }
    }
}

