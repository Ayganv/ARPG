using UnityEngine;

namespace CameraController
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Target Settings")]
        public Transform Target;

        [Space]
        public bool TargetIsPlayer;

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
            UpdateCameraPosition();

            UpdateCameraRotation();
        }

        private void UpdateCameraPosition()
        {
            transform.position = Vector3.Lerp(transform.position, GetDesiredPosition(Target.position), CameraSpeed);
        }

        private void UpdateCameraRotation()
        {
            transform.rotation = RotationOffset;
        }

        private Vector3 GetDesiredPosition(Vector3 TargetPositon)
        {
            return TargetPositon + PositionOffset;
        }
    }
}