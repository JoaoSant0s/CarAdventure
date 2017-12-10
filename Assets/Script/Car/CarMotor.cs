
using System.Collections;
using UnityEngine;

namespace CarAdventure.Entity.Component {
    public class CarMotor : MonoBehaviour {    

        [Header("Object balacing")]
        [SerializeField]
        Transform centerMass;

        [Header("Controller values")]
        [SerializeField]
        float maxTorque;
        [SerializeField]
        float minBoostVelocity;       
        [SerializeField]
        float boostMultiplier;       
        [SerializeField]
        float boostDelay;               
        [SerializeField]
        float dragForce;

        [Header("Wheels Details")]
        [SerializeField]
        WheelCollider[] wheelsColliders = new WheelCollider[4];
        [SerializeField]
        Transform[] wheelsGraphics = new Transform[4];

        Rigidbody rb;
        bool boostActived;            

        void Awake() 
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerMass.localPosition;                    
        }

        void Update() 
        {
            UpdateWheelsGraphic();
        }

        void UpdateWheelsGraphic() 
        {
            for (int i = 0; i < wheelsColliders.Length; i++) {
                wheelsGraphics[i].Rotate(0, -wheelsColliders[i].rpm / 60 * 360 * Time.deltaTime, 0);
                if (i > 1) {
                    wheelsGraphics[i].localEulerAngles = new Vector3(wheelsGraphics[i].localEulerAngles.x, wheelsColliders[i].steerAngle - wheelsGraphics[i].localEulerAngles.z + 90, wheelsGraphics[i].localEulerAngles.z);
                }
            }
        }

        internal void RotateFrontWheels(float steer) 
        {
            var finalSteer = steer * 45f;

            wheelsColliders[2].steerAngle = finalSteer;
            wheelsColliders[3].steerAngle = finalSteer;
        }

        internal void Boost()
        {               
            if(rb.velocity.magnitude <= minBoostVelocity) return;
            if(boostActived) return;
            boostActived = true;             

            var force = transform.forward * maxTorque * boostMultiplier;
            rb.AddForce(force, ForceMode.Impulse);  

            StartCoroutine(StopBoostCoroutine());
        }

        IEnumerator StopBoostCoroutine()
        {
            yield return new WaitForSeconds(boostDelay);
            boostActived = false;                     
        }

        internal void AcelerateCar(float acelerate) 
        {            
            TorqueCar(acelerate);
        }

        internal void BackCar(float acelerate) 
        {
            TorqueCar(acelerate);
        }

        void TorqueCar(float acelerate)
        {            
            ResetDrag();
            var torque = maxTorque * acelerate;            

            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque; 
        }

        void ResetDrag() 
        {
            rb.drag = 0f;
        }

        internal void Drag()
        {            
            rb.drag = dragForce; 
        }
                
    }
}