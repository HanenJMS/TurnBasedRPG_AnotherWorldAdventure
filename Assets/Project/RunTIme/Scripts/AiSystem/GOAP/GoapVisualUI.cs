using AnotherWorldProject.AISystem.GOAP.Core;
using AnotherWorldProject.AISystem.GOAP.GoalSystem;
using AnotherWorldProject.ControllerSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace AnotherWorldProject.AISystem.GOAP.UI
{
    public class GoapVisualUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI GWorldStateText;
        [SerializeField] TextMeshProUGUI GWorldInventoryText;
        [SerializeField] TextMeshProUGUI unitInventory;
        [SerializeField] TextMeshProUGUI unitStateText;
        [SerializeField] TextMeshProUGUI unitgoalStateText;
        [SerializeField] TextMeshProUGUI GLocationStateText;
        [SerializeField] TextMeshProUGUI GLocationInventoryText;
        GAgent unit;
        GLocation location;
        private void Start()
        {
            UnitActionSystem.Instance.onSelectedUnit += UpdateUnit;
            LocationSelectionSystem.Instance.onSelectedLocation += UpdateLocation;
            UpdateUnit();
        }
        private void Update()
        {
            UpdateGWorldStateText();
            UpdateGWorldInventoryText();
            UpdateSelectedUnitInventory();
            UpdateSelectedUnitStateText();
            UpdateUnitCurrentGoalState();
            UpdateGLocationStateText();
            UpdateGLocationInventoryText();
        }
        void UpdateUnit()
        {
            unit = UnitActionSystem.Instance.GetSelectedUnit().gameObject.GetComponent<GAgent>();
        }
        void UpdateLocation()
        {
            location = LocationSelectionSystem.Instance.GetSelectedLocation();
        }
        void UpdateSelectedUnitInventory()
        {
            unitInventory.text = "Unit inventory state" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, List<GameObject>> states in unit.gameObject.GetComponent<GAgent>().GetInventory().GetInventory())
                {
                    unitInventory.text += states.Key + " " + states.Value.Count + "\n";
                }
            }
        }
        void UpdateSelectedUnitStateText()
        {
            unitStateText.text = "unit states" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, int> states in unit.gameObject.GetComponent<GAgent>().GetStateHandler().GetStates())
                {
                    unitStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        private void UpdateUnitCurrentGoalState()
        {
            unitgoalStateText.text = "Goal : Priority" + "\n";
            if (unit != null)
            {
                if (unit.gameObject.GetComponent<GAgent>().GetGoalHandler().GetGoals() == null) return;
                foreach (KeyValuePair<Goal, int> states in unit.gameObject.GetComponent<GAgent>().GetGoalHandler().GetGoals())
                {
                    unitgoalStateText.text += states.Key.ToString() + " " + states.Value + "\n";
                }
            }
        }
        private void UpdateGWorldStateText()
        {
            GWorldStateText.text = "Gworld States" + "\n";
            if (GWorld.Instance.GetGWorldWorldStates().GetStates() != null)
            {
                foreach (KeyValuePair<string, int> states in GWorld.Instance.GetGWorldWorldStates().GetStates())
                {
                    GWorldStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        void UpdateGWorldInventoryText()
        {
            GWorldInventoryText.text = "Gworld Inventory state" + "\n";
            if (unit != null)
            {
                foreach (KeyValuePair<string, List<GameObject>> states in GWorld.Instance.GetWorldInventory().GetInventory())
                {
                    GWorldInventoryText.text += states.Key + " " + states.Value.Count + "\n";
                }
            }
        }
        private void UpdateGLocationStateText()
        {
            GLocationStateText.text = "Gworld States" + "\n";
            if (location != null)
            {
                foreach (KeyValuePair<string, int> states in location.GetStates().GetStates())
                {
                    GLocationStateText.text += states.Key + " " + states.Value + "\n";
                }
            }
        }
        void UpdateGLocationInventoryText()
        {
            GLocationInventoryText.text = "Gworld Inventory state" + "\n";
            if (location != null)
            {
                foreach (KeyValuePair<string, List<GameObject>> states in location.GetInventory().GetInventory())
                {
                    GLocationInventoryText.text += states.Key + " " + states.Value.Count + "\n";
                }
            }
        }
    }
}
