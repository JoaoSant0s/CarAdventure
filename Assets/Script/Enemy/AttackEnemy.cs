using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Enemy {

    [SerializeField]
    float damage = 1f;
    [SerializeField]
    float cooldown = 2f;

    float lastAttackTime;
    bool attacking;
    Animator animator;

    void Awake() {

        TargetCharacter.OnCheckTarget += CheckTarget;
        DeathController.OnUpdateGameState += ResetState;

        lastAttackTime = 0f;
        animator = GetComponent<Animator>();
        animator.enabled = false;
     
    }

    void OnDestroy() {
        TargetCharacter.OnCheckTarget -= CheckTarget;
    }


    void CheckTarget(Vector3 targetDestiny, bool moveToTarget) {
        if (attacking) return;

        if (moveToTarget) {
            animator.enabled = true;
            Motor.Move(targetDestiny);
        } else {
            animator.enabled = false;
            Motor.Move(StartPosition);
        }

    }

    void OnTriggerStay(Collider collider) {
        var car = collider.gameObject.GetComponentInParent<Car>();
        if (car == null) return;
               
        Attack(car);              
    }
    void OnTriggerExit(Collider collider) {
        var car = collider.gameObject.GetComponentInParent<Car>();
        if (car == null) return;

        attacking = false;        
    }

    void ResetState() {
        attacking = false;
        animator.enabled = false;
        Motor.Move(StartPosition);
    }

    void Attack(Car car) {        
        attacking = true;
        Motor.Stop();
        if (lastAttackTime >= Time.timeSinceLevelLoad) return;

        transform.forward = ObjectManipulation.ForwardNormalized(transform.position, car.transform.position);
        lastAttackTime = Time.timeSinceLevelLoad + cooldown;

        car.ReduceLife(damage);          
    }
  
}
