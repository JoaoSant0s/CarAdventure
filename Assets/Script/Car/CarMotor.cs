
using System.Collections;
using UnityEngine;

namespace CarAdventure.Entity.Component {

    public class CarMotor : MonoBehaviour {

        public enum CarState{
            idle,
            back,
            acelerate
        }

        [Header("Object balacing")]
        [SerializeField]
        Transform centerMass;

        [Header("Controller values")]
        [SerializeField]
        float maxTorque;     
        [SerializeField]
        float dragTimeChange;    
        [SerializeField]
        float dragNotInteracting;

        [Header("Wheels Details")]
        [SerializeField]
        WheelCollider[] wheelsColliders = new WheelCollider[4];
        [SerializeField]
        Transform[] wheelsGraphics = new Transform[4];

        Rigidbody rb;
        bool checkDragReducing;
        CarState carState;

        void Awake() 
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerMass.localPosition;
            carState = CarState.idle;            
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

        internal void AcelerateCar(float acelerate) 
        {
            changeState(CarState.acelerate);            
            var torque = maxTorque * acelerate;

            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque;
        }

        internal void BackCar(float acelerate) 
        {
            changeState(CarState.back);
            var torque = maxTorque * acelerate;

            wheelsColliders[0].motorTorque = torque;
            wheelsColliders[1].motorTorque = torque;
        }

        internal void ResetDrag() 
        {
            rb.drag = 0f;
        }

        internal void changeState(CarState newSituation)
        {
            if(newSituation == carState) return;
            carState = newSituation;

            if(newSituation == CarState.acelerate || newSituation == CarState.back)
            {                
                ChangingGears();                
            }else
            {                                
                Drag();
            }               
        }

        void ChangingGears() 
        {                               
            StopCoroutine(DragCoroutine());            
            Drag();
            StartCoroutine(DragCoroutine());
        }

        internal void Drag()
        {
            rb.drag = dragNotInteracting; 
        }
        
        IEnumerator DragCoroutine()
        {
            yield return new WaitForSeconds(dragTimeChange);            
            ResetDrag();
        }

    }
}