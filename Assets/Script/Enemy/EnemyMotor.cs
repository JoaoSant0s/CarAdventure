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

        internal NavMeshAgent PathFinder{
            get{
                return pathFinder;
            }
        }
                
        void Awake()
        {
            pathFinder = GetComponent<NavMeshAgent>();
            body = GetComponent<Rigidbody>();        
        }

        internal void Move(Vector3 targetDestiny) 
        {            
            pathFinder.SetDestination(targetDestiny);
        }

        internal void Stop() 
        {
            pathFinder.ResetPath();
        }
    }

}