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
        float breakCar = Input.GetAxis("Break");
        float acelerateCar = Input.GetAxis("Acelerate");
        
        if (breakCar > 0) {
            carMotor.BackCar(-breakCar);            
        } else {
            if (acelerateCar > 0) {
                carMotor.Reset();
                carMotor.AcelerateCar(acelerateCar);
            }            

            if (acelerateCar == 0) {
                carMotor.ActiveTrackDrag();
            }
        }                            

        carMotor.RotateFrontWheels(steer);
    }
 
}
