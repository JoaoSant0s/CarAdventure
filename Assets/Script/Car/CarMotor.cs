using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                
public class CarMotor : MonoBehaviour {

    [Header("Object balacing")]
    [SerializeField]
    Transform centerMass;
    [SerializeField]
    float backValue;

    [Header("Controller values")]
    [SerializeField]
    float maxTorque;
    [SerializeField]
    float breakTorque;
    [SerializeField]
    float dragNotInteracting;

    [Header("Wheels Details")]
    [SerializeField]
    WheelCollider[] wheelsColliders = new WheelCollider[4];
    [SerializeField]
    Transform[] wheelsGraphics = new Transform[4];

    Rigidbody rb;
    bool backActive;

    void Awake() {
        backActive = false;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerMass.localPosition;
    }

    void Update() {             
        UpdateWheelsGraphic();
    }   

    void UpdateWheelsGraphic() {
        for (int i = 0; i < wheelsColliders.Length; i++) {
            wheelsGraphics[i].Rotate(0, -wheelsColliders[i].rpm / 60 * 360 * Time.deltaTime, 0);
            if( i > 1) {
                wheelsGraphics[i].localEulerAngles = new Vector3(wheelsGraphics[i].localEulerAngles.x, wheelsColliders[i].steerAngle - wheelsGraphics[i].localEulerAngles.z + 90, wheelsGraphics[i].localEulerAngles.z);                
            }            
        }
    }

    internal void RotateFrontWheels(float steer) {
        var finalSteer = steer * 45f;

        wheelsColliders[2].steerAngle = finalSteer;
        wheelsColliders[3].steerAngle = finalSteer;        
    }

    internal void Reset() {
        rb.drag = 0f;
        wheelsColliders[0].brakeTorque = 0f;
        wheelsColliders[1].brakeTorque = 0f;
    }

    internal void AcelerateCar(float acelerate) {
        backActive = false;
        var torque = maxTorque * acelerate;
                
        wheelsColliders[0].motorTorque = torque;
        wheelsColliders[1].motorTorque = torque;
    }

    internal void BackCar(float acelerate) {
        var torque = maxTorque * acelerate;

        if (backActive) {
            Reset();
            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque;
            return;
        }


        if(rb.velocity.sqrMagnitude < backValue) {
            backActive = true;
        } else{
            Break();
        }

    }

    internal void ActiveTrackDrag() {
        rb.drag = dragNotInteracting;
    }
   
    internal void Break() {
        wheelsColliders[0].brakeTorque = rb.mass * breakTorque;
        wheelsColliders[1].brakeTorque = rb.mass * breakTorque;
        
        wheelsColliders[0].motorTorque = 0.0f;
        wheelsColliders[1].motorTorque = 0.0f;

        for (int i = 0; i < wheelsColliders.Length; i++) {
            wheelsGraphics[i].Rotate(0, 0, 0);            
        }

    }

    
}
