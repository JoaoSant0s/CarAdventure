using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public delegate void ChangeCamera();
    public static event ChangeCamera OnChangeCamera;

    CarMotor carMotor;

    void Start() {
        carMotor = GetComponent<CarMotor>();
    }    

    void FixedUpdate() {
        float steer = Input.GetAxis("Horizontal");        
        float backCar = Input.GetAxis("Back");
        float acelerateCar = Input.GetAxis("Acelerate");
        var changeCamera = Input.GetButtonDown("ChangeCamera");

        if (changeCamera) {
            if (OnChangeCamera != null) OnChangeCamera();
        }

        if (backCar > 0) {
            carMotor.BackCar(-backCar);            
        } else {
            if (acelerateCar > 0) {
                carMotor.AcelerateCar(acelerateCar);
            }            

            if (acelerateCar == 0) {
                carMotor.ActiveTrackDrag();
            }
        }
                  
        carMotor.RotateFrontWheels(steer);
        
    }
 
}
