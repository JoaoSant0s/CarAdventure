
using UnityEngine;

namespace CarAdventure.Entity.Component {
    public class ClawCamera : MonoBehaviour {

        [SerializeField]
        private float lookSensitivity = 3f;        
        [SerializeField]
        private Transform center;

        private const float fixedRotation = -90f;

        private Vector3 v;
        private float cameraRotationX = 0f;        
        private float currentCameraRotationX = 0f;        

        void Start()
        {
            Cursor.visible = false;
            v = (transform.position - center.position);
        }

        void Update()
        {
            RotationCamera();
            PerformRotationCamera();
        }

        void RotationCamera()
        {
            float xRot = Input.GetAxis("Mouse X");
            float rotationCameraX = xRot * lookSensitivity;            

            RotationCamera(rotationCameraX);
        }

        void PerformRotation()
        {
            PerformRotationCamera();
        }

        public void RotationCamera(float _cameraRotationX)
        {
            cameraRotationX = _cameraRotationX;
        }
        
        void PerformRotationCamera()
        {
            currentCameraRotationX -= cameraRotationX;            

            var rotation = Quaternion.Euler(0, -currentCameraRotationX + fixedRotation, 0);

            transform.rotation = rotation;
            transform.position = center.position + rotation * v;
        }

    }

}