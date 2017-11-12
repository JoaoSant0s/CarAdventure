
using UnityEngine;
using CarAdventure.Common;
using CarAdventure.Controller.UI;

namespace CarAdventure.Entity { 

    public class AttackEnemy : Enemy {
                
        float lastAttackTime;
        bool attacking;
        Animator animator;

        void Awake() {            
            DeathController.OnUpdateGameState += ResetState;

            lastAttackTime = 0f;
            animator = GetComponent<Animator>();
            animator.enabled = false;
        }        

        internal void CheckTarget(Vector3 targetDestiny, bool moveToTarget) {
            if (attacking) return;

            if (moveToTarget) {
                animator.enabled = true;                
            } else {
                animator.enabled = false;                
            }            
            Motor.Move(targetDestiny);
        }

        void ResetState() {
            attacking = false;
            animator.enabled = false;            
        }

        internal void NotAttack(){
            attacking = false;
        }
        internal void Attack(Car car) {        
            attacking = true;
            Motor.Stop();
            if (lastAttackTime >= Time.timeSinceLevelLoad) return;

            transform.forward = ObjectManipulation.ForwardNormalized(transform.position, car.transform.position);
            lastAttackTime = Time.timeSinceLevelLoad + cooldown;

            car.ReduceLife(attack);          
        }
    }
}