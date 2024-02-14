using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.AISystem.GOAP
{
    public class GWorldLocations
    {
        Dictionary<string, GLocation> locationDictionary = new();
        internal void AddLocation(string locationName, GLocation location)
        {
            locationDictionary.Add(locationName, location);
        }

        public GLocation GetLocation(string locationName)
        {
            if (!locationDictionary.ContainsKey(locationName)) return null;
            return locationDictionary[locationName];
        }
    }
}
