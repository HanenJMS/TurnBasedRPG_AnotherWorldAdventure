
using AnotherWorldProject.UI_System;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace AnotherWorldProject.BuildingSystem
{
    public class BuildingModeSystemUI : MonoBehaviour
    {
        [SerializeField] Transform startButtonContainer;
        [SerializeField] InteractionButtonUI startButtonPrefab;


        [SerializeField] Transform SelectionMenuContainer;
        [SerializeField] SelectableButtonUI selectableBuildingButtonPrefab;
        [SerializeField] List<SelectableButtonUI> selectableConstructionMenuList = new();

        [SerializeField] Transform QuestionDialogContainer;
        [SerializeField] InteractionButtonUI QuestionDialogButtonUI;
        [SerializeField] InteractionButtonUI activeDialogUI;

        private void Start()
        {
            GameObject buttonObject = Instantiate(startButtonPrefab.gameObject, startButtonContainer);
            InteractionButtonUI interactionButtonUI = buttonObject.GetComponent<InteractionButtonUI>();
            interactionButtonUI.SetInteractionButton("BuildingMode", () => StartBuildingMode());

            BuildingModeSystem.Instance.onConfirmPlacement += ConfirmPlacement;
            BuildingModeSystem.Instance.onCancelBuildingMode += CancelBuildingModeUI;
            BuildingInteractionSystem.Instance.onSelectedBuilding += CancelBuildingModeUI;
        }

        void ConfirmPlacement(Action action, Vector3 mousePosition)
        {
            ClearDialogUI();
            QuestionDialogContainer.gameObject.SetActive(true);
            QuestionDialogContainer.position = mousePosition;
            GameObject dialog = Instantiate(QuestionDialogButtonUI.gameObject, QuestionDialogContainer);
            dialog.TryGetComponent<InteractionButtonUI>(out InteractionButtonUI buttonUI);
            if (buttonUI != null) buttonUI.SetInteractionButton("Yes?", () => 
            { 
                action();
                ClearDialogUI();
            });
            activeDialogUI = buttonUI;
        }
        void StartBuildingMode()
        {
            SwapUI(true);
            UpdateSelectionMenu();
        }
        void CancelBuildingModeUI()
        {
            SwapUI(false);
            ClearSelectionMenu();
            ClearDialogUI();
        }
        void SwapUI(bool isActive)
        {
            startButtonContainer.gameObject.SetActive(!isActive);
            SelectionMenuContainer.gameObject.SetActive(isActive);
            
        }
        void ClearDialogUI()
        {
            if (activeDialogUI != null)
            {
                Destroy(activeDialogUI.gameObject);
                activeDialogUI = null;
            }
        }
        void UpdateSelectionMenu()
        {
            ClearSelectionMenu();
            foreach (GameObject selectableBuildingMenu in BuildingModeSystem.Instance.GetConstructableList())
            {
                selectableBuildingMenu.TryGetComponent<Building>(out Building building);
                SelectableButtonUI selectableBuildingButton = Instantiate(selectableBuildingButtonPrefab.gameObject, SelectionMenuContainer).GetComponent<SelectableButtonUI>();
                selectableBuildingButton.SetSelectableUI(building.gameObject, () =>
                {
                    BuildingModeSystem.Instance.SetSelectedBuilding(building.gameObject);
                });
                selectableConstructionMenuList.Add(selectableBuildingButton);
            }
        }
        void ClearSelectionMenu()
        {

            if (selectableConstructionMenuList.Count == 0) return;
            foreach(SelectableButtonUI button in selectableConstructionMenuList)
            {
                Destroy(button.gameObject);
            }
            selectableConstructionMenuList.Clear();
        }
    }

}
