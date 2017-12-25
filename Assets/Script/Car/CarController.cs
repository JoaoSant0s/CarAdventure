
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Controller {
    public class CarController : MonoBehaviour {

        public delegate void ChangeCamera();
        public static event ChangeCamera OnChangeCamera;

        [SerializeField]        
        CarMotor carMotor;
        
        [SerializeField]
        AudioSource audio;

        void Update() {            
            var changeCamera = Input.GetButtonDown("ChangeCamera");

            if (!changeCamera) return;

            if (OnChangeCamera != null) OnChangeCamera();        
        }                   

        void FixedUpdate() {
            float steer = Input.GetAxis("Horizontal");        
            float backCar = Input.GetAxis("Back");
            float acelerateCar = Input.GetAxis("Acelerate");                         

            if(Input.GetAxis("Boost") > 0) carMotor.Boost();

            if(Input.GetAxis("Drag") > 0){
                StopAceleration();
                carMotor.Drag();            
            }else{
                if (backCar > 0) 
                {
                    StopAceleration();
                    carMotor.BackCar(-backCar);            
                } 

                if (acelerateCar > 0) 
                {
                    PlayAceleration();
                    carMotor.AcelerateCar(acelerateCar);
                }                        
            }
                              
            carMotor.RotateFrontWheels(steer);        
        }    

        void PlayAceleration() 
        {
            if(!audio.isPlaying) audio.Play();
        }

        void StopAceleration() 
        {
            if (audio.isPlaying) audio.Stop();       
        }
 
    }

}