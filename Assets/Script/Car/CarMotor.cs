﻿
using UnityEngine;

namespace CarAdventure.Entity.Component {

    public class CarMotor : MonoBehaviour {

        [Header("Object balacing")]
        [SerializeField]
        Transform centerMass;

        [Header("Controller values")]
        [SerializeField]
        float maxTorque;
        [SerializeField]
        float dragNotInteracting;

        [Header("Wheels Details")]
        [SerializeField]
        WheelCollider[] wheelsColliders = new WheelCollider[4];
        [SerializeField]
        Transform[] wheelsGraphics = new Transform[4];

        Rigidbody rb;

        void Awake() {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerMass.localPosition;
        }

        void Update() {
            UpdateWheelsGraphic();
        }

        void UpdateWheelsGraphic() {
            for (int i = 0; i < wheelsColliders.Length; i++) {
                wheelsGraphics[i].Rotate(0, -wheelsColliders[i].rpm / 60 * 360 * Time.deltaTime, 0);
                if (i > 1) {
                    wheelsGraphics[i].localEulerAngles = new Vector3(wheelsGraphics[i].localEulerAngles.x, wheelsColliders[i].steerAngle - wheelsGraphics[i].localEulerAngles.z + 90, wheelsGraphics[i].localEulerAngles.z);
                }
            }
        }

        internal void RotateFrontWheels(float steer) {
            var finalSteer = steer * 45f;

            wheelsColliders[2].steerAngle = finalSteer;
            wheelsColliders[3].steerAngle = finalSteer;
        }

        internal void AcelerateCar(float acelerate) {
            var torque = maxTorque * acelerate;

            Reset();
            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque;
        }

        internal void BackCar(float acelerate) {
            var torque = maxTorque * acelerate;

            ActiveTrackDrag();
            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque;
        }

        internal void Reset() {
            rb.drag = 0f;
        }

        internal void ActiveTrackDrag() {
            rb.drag = dragNotInteracting;
        }

    }
}