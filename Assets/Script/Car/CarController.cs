
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Controller { 
    public class CarController : MonoBehaviour {

        public delegate void ChangeCamera();
        public static event ChangeCamera OnChangeCamera;

        CarMotor carMotor;
        AudioSource audio;

        void Start() {
            carMotor = GetComponent<CarMotor>();
            audio = GetComponent<AudioSource>();
        } 
        void Update() {
            var changeCamera = Input.GetButtonDown("ChangeCamera");

            if (!changeCamera) return;

            if (OnChangeCamera != null) OnChangeCamera();        
        }   

        void FixedUpdate() {
            float steer = Input.GetAxis("Horizontal");        
            float backCar = Input.GetAxis("Back");
            float acelerateCar = Input.GetAxis("Acelerate");
        

            if (backCar > 0) {
                StopAceleration();
                carMotor.BackCar(-backCar);            
            } else {
                if (acelerateCar > 0) {
                    PlayAceleration();
                    carMotor.AcelerateCar(acelerateCar);
                }            

                if (acelerateCar == 0) {
                    StopAceleration();
                    carMotor.ActiveTrackDrag();
                }
            }
                  
            carMotor.RotateFrontWheels(steer);
        
        }

        void PlayAceleration() {
            if(!audio.isPlaying) audio.Play();
        }

        void StopAceleration() {
            if (audio.isPlaying) audio.Stop();       
        }
 
    }

}