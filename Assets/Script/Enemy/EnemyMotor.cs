using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace CarAdventure.Entity.Component {

    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMotor : MonoBehaviour {    

        Rigidbody body;
        NavMeshAgent pathFinder;    

        float smoothDirection;
        float smoothDirectionVelocity;
  
        void Start() {
            pathFinder = GetComponent<NavMeshAgent>();

            body = GetComponent<Rigidbody>();        
        }   

        public void Move(Vector3 targetDestiny) {
            pathFinder.SetDestination(targetDestiny);
        }

        public void Stop() {
            pathFinder.ResetPath();
        }
    }

}