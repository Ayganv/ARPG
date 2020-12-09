using UnityEngine;

namespace CameraController
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Zoom Settings")]
        public bool CameraCanZoom = true;

        [Space]
        public Vector3 CameraDirection;

        [Header("Camera Movement Settings")]
        [Range(0, 1)]
        public float CameraSpeed;

        [Header("Camera Direction")]
        public bool LookAtTarget = false;

        [Header("Camera Offset Settings")]
        public Vector3 PositionOffset;

        [Header("Camera Target Settings")]
        public Transform Target;

        [Space]
        public Vector2 ZoomDistanceMinMax = new Vector2(5, 30);

        [Space]
        [Range(0, 1)]
        public float ZoomSpeed;

        private bool ZoomIsClamped;

        private Transform CameraObject => transform.GetChild(0);
        private Camera MainCamera => CameraObject.GetComponent<Camera>();

        private void LateUpdate()
        {
            if (Target == null)
            {
                Debug.LogError("Camera has no target");

                return;
            }

            if (CameraCanZoom)
            {
                if (MainCamera.orthographic)
                {
                    UpdateOrthographicZoom();
                }
                else
                {
                    UpdatePerspectiveZoom();
                }
            }

            UpdateCameraPosition();

            UpdateCameraDirection();
        }

        private void Start()
        {
            UpdateCameraOffset();
        }

        #region Zoom

        private void UpdatePerspectiveZoom()
        {
            float distance = Vector3.Distance(Target.position, CameraObject.position);

            ClampZoom(distance, Input.GetAxis("Mouse ScrollWheel"));

            if (!ZoomIsClamped)
            {
                CameraObject.position += CameraObject.forward * Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
            }
        }

        private void UpdateOrthographicZoom()
        {
            ClampZoom(MainCamera.orthographicSize, Input.GetAxis("Mouse ScrollWheel"));

            if (!ZoomIsClamped)
            {
                MainCamera.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
            }
        }

        private void ClampZoom(float ZoomAmount, float scrollAmount)
        {
            if (ZoomAmount <= ZoomDistanceMinMax.x && scrollAmount > 0)
            {
                ZoomIsClamped = true;
            }
            else if (ZoomAmount >= ZoomDistanceMinMax.y && scrollAmount < 0)
            {
                ZoomIsClamped = true;
            }
            else
            {
                ZoomIsClamped = false;
            }
        }

        #endregion Zoom

        #region Follow Player

        private void UpdateCameraOffset()
        {
            CameraObject.position = transform.position + PositionOffset;
        }

        private void UpdateCameraPosition()
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, CameraSpeed);
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