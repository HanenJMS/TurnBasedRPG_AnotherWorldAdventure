using AnotherWorldProject.BuildingSystem;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.UI_System
{
    public class BuildingInteractionSystemUI : MonoBehaviour
    {
        [SerializeField] Transform InteractionButtonContainer;
        [SerializeField] Transform InteractionButtonUI;
        [SerializeField] List<InteractionButtonUI> buttons = new();
        Building selectedBuilding;

        private void Start()
        {
            BuildingInteractionSystem.Instance.onSelectedBuilding += OnBuildingSelected;
            BuildingInteractionSystem.Instance.onEndInteraction += ClearUI;
        }
        void OnBuildingSelected()
        {
            ClearUI();
            selectedBuilding = BuildingInteractionSystem.Instance.GetSelectedBuilding();
            StartUI();
        }

        void StartUI()
        {

            InteractionButtonContainer.position = Input.mousePosition;
            EnterButton();
            DemolishButton();

        }
        void EnterButton()
        {
            GameObject uButton = Instantiate(InteractionButtonUI, InteractionButtonContainer).gameObject;
            InteractionButtonUI interactionButton = uButton.GetComponent<InteractionButtonUI>();
            interactionButton.SetInteractionButton("Enter", () =>
            {
                selectedBuilding.Use();
                BuildingInteractionSystem.Instance.EndBuildingInteraction();
            });
            buttons.Add(interactionButton);
        }
        void DemolishButton()
        {
            GameObject uButton = Instantiate(InteractionButtonUI, InteractionButtonContainer).gameObject;
            InteractionButtonUI interactionButton = uButton.GetComponent<InteractionButtonUI>();
            interactionButton.SetInteractionButton("Demolish", () =>
            {
                selectedBuilding.Demolish();
                BuildingInteractionSystem.Instance.EndBuildingInteraction();
            });
            buttons.Add(interactionButton);
        }
        void ClearUI()
        {
            if (buttons.Count == 0) return;
            foreach (InteractionButtonUI uibutton in buttons)
            {
                Destroy(uibutton.gameObject);
            }
            buttons.Clear();
        }
    }
}

