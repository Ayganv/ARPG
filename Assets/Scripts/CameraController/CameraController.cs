﻿using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Target Settings")]
        public Transform Target;

        [Header("Camera Direction")]
        public bool LookAtTarget = false;

        [Space]
        public Vector3 CameraDirection;

        [Header("Camera Zoom Settings")]
        public bool CameraCanZoom = true;

        [Space]
        [Range(0, 1)]
        public float ZoomSpeed;

        [Space]
        public Vector2 ZoomDistanceMinMax = new Vector2(5, 30);

        [Header("Camera Offset Settings")]
        public Vector3 PositionOffset;

        [Header("Camera Movement Settings")]
        [Range(0, 1)]
        public float CameraSpeed;

        private Transform CameraObject => transform.GetChild(0);
        private Camera MainCamera => CameraObject.GetComponent<Camera>();

        private void Start()
        {
            UpdateCameraOffset();
        }

        private void LateUpdate()
        {
            if (Target == null)
            {
                Debug.LogError("Camera has no target");

                return;
            }

            if (CameraCanZoom)
            {
                UpdateZoom();
            }

            UpdateCameraPosition();

            UpdateCameraDirection();
        }

        #region Zoom

        //TODO: Clean up method later not priority

        private void UpdateZoom()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            float distance = Vector3.Distance(Target.position, CameraObject.position);

            if (distance <= ZoomDistanceMinMax.x && scrollInput > 0 || MainCamera.orthographicSize <= ZoomDistanceMinMax.x && scrollInput > 0)
            {
                return;
            }
            else if (distance >= ZoomDistanceMinMax.y && scrollInput < 0 || MainCamera.orthographicSize >= ZoomDistanceMinMax.y && scrollInput < 0)
            {
                return;
            }

            if (MainCamera.orthographic)
            {
                MainCamera.orthographicSize -= scrollInput * ZoomSpeed;
            }
            else
            {
                CameraObject.position += CameraObject.forward * scrollInput * ZoomSpeed;
            }
        }

        #endregion Zoom

        #region Follow Player

        private void UpdateCameraPosition()
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, CameraSpeed);
        }

        private void UpdateCameraOffset()
        {
            CameraObject.position = transform.position + PositionOffset;
        }

        #endregion Follow Player

        #region Camera Direction

        private void UpdateCameraDirection()
        {
            if (LookAtTarget)
            {
                CameraObject.LookAt(Target);
            }
            else
            {
                CameraObject.rotation = Quaternion.Euler(CameraDirection.x, CameraDirection.y, CameraDirection.z);
            }
        }

        #endregion Camera Direction
    }
}