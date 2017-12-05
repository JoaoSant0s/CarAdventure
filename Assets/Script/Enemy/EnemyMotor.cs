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

        Vector3 destinyPosition;        

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

        internal float GetVelocity()
        {
            return pathFinder.velocity.magnitude;
        }

        internal void Move(Vector3 targetDestiny) 
        {
            destinyPosition = targetDestiny;            
            MoveExtention(destinyPosition);
        }

        internal void MoveExtention(Vector3 targetDestiny)
        {            
            pathFinder.SetDestination(targetDestiny);           
        }        
        
        internal void Resume()
        {
            if (destinyPosition ==  null) return;
            MoveExtention(destinyPosition);
        }

        internal void Stop() 
        {
            MoveExtention(transform.position);            
        }
    }

}