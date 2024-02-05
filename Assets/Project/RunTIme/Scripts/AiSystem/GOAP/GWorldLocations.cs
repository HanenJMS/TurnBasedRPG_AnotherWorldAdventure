using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP.Core
{
    public class GWorldLocations
    {
        Dictionary<string, GameObject> locationDictionary = new();
        internal void AddLocation(string locationName, GameObject gameObject)
        {
            locationDictionary.Add(locationName, gameObject);
        }

        public GameObject GetLocation(string locationName)
        {
            if (!locationDictionary.ContainsKey(locationName)) return null;
            return locationDictionary[locationName];
        }
    }
}
