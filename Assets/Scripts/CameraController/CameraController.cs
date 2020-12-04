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
        public Transform CameraObject;

        [Header("Camera Zoom Settings")]
        public bool CameraCanZoom = true;

        [Space]
        public float ZoomSpeed;

        [Space]
        public Vector2 ZoomDistanceMinMax = new Vector2(5, 30);

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
            else if (Target == null && !TargetIsPlayer)
            {
                Debug.LogError("Camera Has No Target");
            }

            SetupStartingPosition();
        }

        private void LateUpdate()
        {
            if (CameraCanZoom)
            {
                UpdateZoom();
            }

            FollowPlayer();

            UpdateCameraRotation();
        }

        private void UpdateZoom()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            float distance = Vector3.Distance(Target.position, CameraObject.position);

            if (distance <= ZoomDistanceMinMax.x && scrollInput > 0)
            {
                return;
            }
            else if (distance >= ZoomDistanceMinMax.y && scrollInput < 0)
            {
                return;
            }

            CameraObject.position += CameraObject.forward * scrollInput * ZoomSpeed;
        }

        private void FollowPlayer()
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, CameraSpeed);
        }

        private void SetupStartingPosition()
        {
            CameraObject.position = PositionOffset;
        }

        private void UpdateCameraRotation()
        {
            transform.rotation = RotationOffset;
        }
    }
}