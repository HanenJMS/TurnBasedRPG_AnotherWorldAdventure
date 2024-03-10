using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnotherWorldProject.UI_System
{
    public class InteractionButtonUI : MonoBehaviour
    {
        Button button;
        [SerializeField]
        TextMeshProUGUI text;
        private void Awake()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetInteractionButton(string interactionName, Action buttonAction)
        {
            text.text = interactionName;
            button.onClick.AddListener(() =>
            {
                buttonAction();
            });
        }
        public void Close()
        {
            Destroy(this.gameObject);
        }
    }
}

