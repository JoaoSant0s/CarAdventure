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
        System.Func<bool> savedFunction;

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

        internal void Move(Vector3 targetDestiny, System.Func<bool> callback) 
        {
            destinyPosition = targetDestiny;
            savedFunction = callback;
            MoveExtention(destinyPosition, savedFunction);
        }

        internal void MoveExtention(Vector3 targetDestiny, System.Func<bool> callback)
        {
            //Debug.Log(targetDestiny);
            pathFinder.SetDestination(targetDestiny);
            StartCoroutine(CheckMove(callback));
        }

        IEnumerator CheckMove(System.Func<bool> callback)
        {
            yield return new WaitUntil(() =>
            {
                return !pathFinder.pathPending;
            });
            callback();
        }
        
        internal void Resume()
        {
            if (destinyPosition ==  null) return;
            MoveExtention(destinyPosition, savedFunction);
        }

        internal void Stop() 
        {
            MoveExtention(transform.position, savedFunction);            
            //pathFinder.ResetPath();
        }
    }

}