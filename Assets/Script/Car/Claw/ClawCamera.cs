
using UnityEngine;

namespace CarAdventure.Entity.Component {
    public class ClawCamera : MonoBehaviour {

        [SerializeField]
        private float lookSensitivity = 3f;
        [SerializeField]
        private float cameraRotationLimitY = 45f;
        [SerializeField]
        private Transform center;

        private const float fixedRotation = -90f;

        private Vector3 v;
        private float cameraRotationX = 0f;
        private float cameraRotationY = 0f;
        private float currentCameraRotationX = 0f;
        private float currentCameraRotationY = 0f;

        void Start() {
            Cursor.visible = false;
            v = (transform.position - center.position);
        }

        void Update() {
            RotationCamera();
            PerformRotationCamera();
        }

        void RotationCamera() {
            float xRot = Input.GetAxis("Mouse X");
            float rotationCameraX = xRot * lookSensitivity;

            float yRot = Input.GetAxis("Mouse Y");
            float rotationCameraY = yRot * lookSensitivity;

            RotationCamera(rotationCameraX, rotationCameraY);
        }

        void PerformRotation() {
            PerformRotationCamera();
        }

        public void RotationCamera(float _cameraRotationX, float _cameraRotationY) {
            cameraRotationX = _cameraRotationX;
            cameraRotationY = _cameraRotationY;
        }
        
        void PerformRotationCamera() {
            currentCameraRotationX -= cameraRotationX;

            currentCameraRotationY -= cameraRotationY;
            currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraRotationLimitY, cameraRotationLimitY);

            var rotation = Quaternion.Euler(currentCameraRotationY, -currentCameraRotationX + fixedRotation, 0);

            transform.rotation = rotation;
            transform.position = center.position + rotation * v;
        }

    }

}