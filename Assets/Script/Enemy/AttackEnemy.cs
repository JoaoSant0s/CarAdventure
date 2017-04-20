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

    void Awake() {
        lastAttackTime = 0f;
        TargetCharacter.OnCheckTarget += CheckTarget;
    }

    void OnDestroy() {
        TargetCharacter.OnCheckTarget -= CheckTarget;
    }


    void CheckTarget(Vector3 targetDestiny, bool moveToTarget) {
        if (attacking) return;

        if (moveToTarget) {
            Motor.Move(targetDestiny);
        } else {
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


    void Attack(Car car) {
        attacking = true;
        if (lastAttackTime >= Time.timeSinceLevelLoad) return;
                
        lastAttackTime = Time.timeSinceLevelLoad + cooldown;

        Debug.Log(transform.forward);
    }
  
}
