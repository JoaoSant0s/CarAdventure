
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Entity { 

    public class Enemy : MonoBehaviour {
        [Header("Data")]
        [SerializeField]
        internal float life;
        [SerializeField]
        internal float attack;
        [SerializeField]
        internal float velocity;                
        [SerializeField]
        internal float cooldown = 2f;

        EnemyMotor motor;        
        
        void Awake() {
            motor = GetComponent<EnemyMotor>();    
            motor.PathFinder.speed = velocity;
        }        
        
        internal EnemyMotor Motor {
            get {
                if(motor){
                    return motor;
                } else{
                    motor = GetComponent<EnemyMotor>();    
                }
                return motor; }
        }
           
    }
}