using UnityEngine;

namespace Main.Scripts
{
    public class PlatformRotator : MonoBehaviour
    {
        [SerializeField] private Transform heroRoot;
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private TouchController touchController;

        private Vector2 _startPoint;
        private float _startHeroAngle;
        private float _startCameraAngle;

        private const float RotationSpeed = 2f;
        private const float CameraMaxAngle = .2f;
        private const float CameraMinAngle = -.5f;

        private void Start()
        {
            touchController.IsBegan += StartRotate;
            touchController.IsMoved += ContinueRotate;
        }

        private void StartRotate(Vector2 point)
        {
            _startPoint = point;
            _startHeroAngle = heroRoot.localRotation.y;
            _startCameraAngle = cameraRoot.localRotation.x;
        }

        private void ContinueRotate(Vector2 point)
        {
            var localCameraRotation = cameraRoot.localRotation;
            localCameraRotation = new Quaternion(
                CheckCameraAngle(_startCameraAngle - (_startPoint.y - point.y) * RotationSpeed),
                localCameraRotation.y, localCameraRotation.z, localCameraRotation.w);
            cameraRoot.localRotation = localCameraRotation;

            var localHeroRotation = heroRoot.localRotation;
            localHeroRotation = new Quaternion(localHeroRotation.x,
                _startHeroAngle + (_startPoint.x - point.x) * RotationSpeed,
                localHeroRotation.z, localCameraRotation.w);
            heroRoot.localRotation = localHeroRotation;
        }

        private static float CheckCameraAngle(float angle)
        {
            if (angle < CameraMinAngle)
            {
                angle = CameraMinAngle;
            }

            if (angle > CameraMaxAngle)
            {
                angle = CameraMaxAngle;
            }

            return angle;
        }
    }
}