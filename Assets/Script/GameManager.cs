using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Camera firstPersonCamera;
    [SerializeField]
    private Camera overheadCamera;

    bool topCamera;

    void Awake() {
        ShowFirstPersonView();
        topCamera = false;

        CarController.OnChangeCamera += CameraController;
    }

    void CameraController() {

        if (topCamera) {
            ShowOverheadView();
            topCamera = false;
        } else {
            ShowFirstPersonView();
            topCamera = true;
        }
    }

    void ShowOverheadView() {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }
    void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
     
		
}
