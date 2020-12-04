using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Target Settings")]
        public Transform Target;

        [Space]
        public bool TargetIsPlayer;

        [Space]
        public Transform CameraFocus;

        [Header("Camera Zoom Settings")]
        public bool CameraCanZoom = true;

        [Space]
        public float ZoomSpeed;

        [Space]
        public float ZoomMin;

        public float ZoomMax;

        [Header("Camera Offset Settings")]
        public Vector3 PositionOffset;

        [Space]
        public Quaternion RotationOffset;

        [Header("Camera Movement Settings")]
        [Range(0, 1)]
        public float CameraSpeed;

        private void Start()
        {
            if (Target == null && TargetIsPlayer)
            {
                Target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            else if (!TargetIsPlayer)
            {
                Debug.LogError("Camera Has No Target");
            }
        }

        private void LateUpdate()
        {
            if (CameraCanZoom)
            {
                UpdateZoom();
            }

            UpdateCameraPosition();

            UpdateCameraRotation();
        }

        private void UpdateZoom()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            float distance = Vector3.Distance(Target.position, transform.position);

            if (distance < ZoomMin && scrollInput > 0)
            {
                return;
            }
            else if (distance > ZoomMax && scrollInput < 0)
            {
                return;
            }

            transform.position += transform.forward * scrollInput * ZoomSpeed;
        }

        private void UpdateCameraPosition()
        {
            CameraFocus.position = Vector3.Lerp(CameraFocus.position, GetDesiredPosition(Target.position), CameraSpeed);
        }

        private void UpdateCameraRotation()
        {
            CameraFocus.rotation = RotationOffset;
        }

        private Vector3 GetDesiredPosition(Vector3 TargetPositon)
        {
            return TargetPositon + PositionOffset;
        }
    }
}