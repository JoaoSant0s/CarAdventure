using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float cameraRotationLimitX = 85f;
    [SerializeField]
    private float cameraRotationLimitY = 45f;
    [SerializeField]
    private Transform center;

    private Vector3 v;
    private float cameraRotationX = 0f;
    private float cameraRotationY = 0f;
    private float currentCameraRotationX = 0f;
    private float currentCameraRotationY = 0f;

    void Start() {
        v = (transform.position - center.position);
    }

    void Update() {        
        RotationCamera();
    }

    void RotationCamera() {
        float xRot = Input.GetAxisRaw("Mouse X");
        float rotationCameraX = xRot * lookSensitivity;

        float yRot = Input.GetAxisRaw("Mouse Y");
        float rotationCameraY = yRot * lookSensitivity;        
        RotationCamera(rotationCameraX, rotationCameraY);
    }

    void FixedUpdate() {        
        PerformRotationCamera();
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
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimitX, cameraRotationLimitX);

        currentCameraRotationY -= cameraRotationY;
        currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraRotationLimitY, cameraRotationLimitY);
        var rotation = new Vector3(currentCameraRotationY, -currentCameraRotationX, 0f);
        transform.localEulerAngles = rotation;

        transform.position = center.position + Quaternion.Euler(rotation) * v;
    }

}
    
