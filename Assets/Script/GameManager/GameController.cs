using UnityEngine;
using CarAdventure.Entity;
using CarAdventure.Environment;

namespace CarAdventure.Controller { 

    public class GameController : MonoBehaviour {    
        
        [SerializeField]
        private Camera firstPersonCamera;
        [SerializeField]
        private Camera overheadCamera;
        [SerializeField]
        private Camera doorCamera;

        bool topCamera;
        bool blockControllerCamera;   
       
        void Awake() {
            doorCamera.enabled = false;
            ShowFirstPersonView();
            blockControllerCamera = false;
            topCamera = false;
            Car.OnDestroyCar += ActiveOverheadCamera;
            CarController.OnChangeCamera += CameraController;            
        }        

        void CameraController() {
            if (blockControllerCamera) return;

            if (firstPersonCamera == null) {
                firstPersonCamera = Camera.main;
            }

            if (topCamera) {
                ShowOverheadView();
                topCamera = false;
            } else {
                ShowFirstPersonView();
                topCamera = true;
            }
        }

        void ActiveOverheadCamera() {
            topCamera = false;        
            overheadCamera.enabled = true;
        }

        void ActiveDoorCamera() {
            firstPersonCamera.enabled = false;
            overheadCamera.enabled = false;
            doorCamera.enabled = true;
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
}