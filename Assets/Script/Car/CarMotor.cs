using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                
public class CarMotor : MonoBehaviour {

    [Header("Object balacing")]
    [SerializeField]
    Transform centerMass;

    [Header("Controller values")]
    [SerializeField]
    float maxTorque;
    
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
        }
    }

    internal void RotateFrontWheels(float steer) {
        var finalSteer = steer * 45f;

        wheelsColliders[2].steerAngle = finalSteer;
        wheelsColliders[3].steerAngle = finalSteer;                
    }

    internal void AcelerateCar(float acelerate) {
        var torque = maxTorque * acelerate;        

        wheelsColliders[0].motorTorque = torque;
        wheelsColliders[1].motorTorque = torque;        
    }
}
