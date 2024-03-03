using UnityEngine;
using UnityEngine.InputSystem;

namespace AnotherWorldProject.ControllerSystem
{
    public class DashAction : MonoBehaviour
    {

        private float duration = 1f;
        private float startDuration = float.MaxValue;
        private float distance = 5f;
        Vector3 lookDirection;
        Vector3 endPosition;

        private void Update()
        {
            HandleAction();
        }
        private void HandleAction()
        {
            if (startDuration < duration)
            {
                startDuration += Time.deltaTime;

                transform.position = Vector3.Lerp(transform.position, endPosition, startDuration / duration);
            }
        }

        public void TakeAction(InputAction.CallbackContext context)
        {
            if (startDuration < duration) return;
            if(context.performed)
            {
                startDuration = 0f;
                lookDirection = MouseWorld.GetMousePosition();
                transform.LookAt(lookDirection);
                endPosition = Vector3.MoveTowards(transform.position, lookDirection, distance);
                
            }
        }
    }
}

