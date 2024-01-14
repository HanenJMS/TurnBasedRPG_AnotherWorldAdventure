using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class TurnSystem : MonoBehaviour
    {
        int currentTurn = 0;
        float currentTimer = 0f;
        public static TurnSystem Instance { get; private set; }
        public Action onTimerChanged;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
        }
        public int GetTurnNumber() => currentTurn;
        private void Update()
        {
            currentTimer += Time.deltaTime * 1f;
            if (currentTimer >= 5f)
            {
                currentTimer = 0f;
                currentTurn++;
                onTimerChanged?.Invoke();
            }
        }
    }

}
