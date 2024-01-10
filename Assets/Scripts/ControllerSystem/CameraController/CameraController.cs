using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnotherWorldProject.ControllerSystem
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera cinemachineCamera;
        float moveSpeed = 10f;
        float rotationSpeed = 100f;
        float zoomAmount = 1f;
        const float MIN_FOLLOW_Y = 2f;
        const float MAX_FOLLOW_Y = 12f;
        Vector3 targetFollowOffset;
        CinemachineTransposer cineMachineTransposer;

        private void Start()
        {
            cineMachineTransposer = cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
            targetFollowOffset = cineMachineTransposer.m_FollowOffset;
        }

        private void Update()
        {
            HandleCameraMovement();
            HandleCameraRotation();
            HandleCameraZoom();
        }

        private void HandleCameraMovement()
        {
            Vector3 moveDirection = new(0, 0, 0);
            moveDirection.x = Input.GetAxis("Horizontal");
            moveDirection.z = Input.GetAxis("Vertical");

            float moveSpeed = 5f;
            Vector3 moveVector = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            transform.position += moveVector * moveSpeed * Time.deltaTime;
        }

        private void HandleCameraRotation()
        {
            Vector3 rotationVector = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.Q))
            {
                rotationVector.y = -1f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                rotationVector.y = +1f;
            }
            transform.eulerAngles += rotationVector * Time.unscaledDeltaTime * rotationSpeed;
        }
        private void HandleCameraZoom()
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                targetFollowOffset.y += zoomAmount;
            }
            if (Input.mouseScrollDelta.y > 0)
            {
                targetFollowOffset.y -= zoomAmount;
            }
            float zoomSpeed = 5f;
            targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y, MAX_FOLLOW_Y);
            cineMachineTransposer.m_FollowOffset = Vector3.Lerp(cineMachineTransposer.m_FollowOffset, targetFollowOffset, Time.unscaledDeltaTime * zoomSpeed);
        }
    }
}


