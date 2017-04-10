using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    CarMotor carMotor;

    void Start() {
        carMotor = GetComponent<CarMotor>();
    }    

    void FixedUpdate() {
        float steer = Input.GetAxis("Horizontal");
        float acelerate = Input.GetAxis("Vertical");
        float breakCar = Input.GetAxis("Break");
        
        if (breakCar > 0) {
            carMotor.Break();
        } else {
            carMotor.Reset();
            carMotor.AcelerateCar(acelerate);
        }

        carMotor.RotateFrontWheels(steer);

    }
 
}
