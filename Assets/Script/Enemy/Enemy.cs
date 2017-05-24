
using UnityEngine;
using CarAdventure.Entity.Component;

namespace CarAdventure.Entity { 

    public class Enemy : MonoBehaviour {

        EnemyMotor motor;
        Vector3 startPosition;

        void Start() {
            motor = GetComponent<EnemyMotor>();
            startPosition = transform.position;
        }
        public Vector3 StartPosition {
            get { return startPosition; }
        }


        public EnemyMotor Motor {
            get { return motor; }
        }
           
    }
}