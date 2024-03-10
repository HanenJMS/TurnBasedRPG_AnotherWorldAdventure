using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnotherWorldProject.BuildingSystem
{
    public class SelectableButtonUI : MonoBehaviour
    {
        Button button;
        GameObject selectableUI;
        [SerializeField]
        TextMeshProUGUI text;
        private void Awake()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            
        }
        public void SetSelectableUI(GameObject selectableUI, Action selectableUIAction)
        {
            this.selectableUI = selectableUI;
            text.text = selectableUI.gameObject.name;
            button.onClick.AddListener(() =>
            {
                selectableUIAction();
            });
        }

    }

}
