using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

namespace CarAdventure.Entity.Component {
    public class EnemyAttackZone : MonoBehaviour
    {        
        AttackEnemy enemyController;
        Car attackedEnemy;

        void Awake()
        {
            enemyController = GetComponent<AttackEnemy>();
        }

        internal bool IsAttackingEnemy
        {
            get { return attackedEnemy != null; }
        }

        void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.tag == "Ship")
            {
                enemyController.AttackShip(collider.GetComponent<ShipController>());
            }
            else
            {
                attackedEnemy = collider.gameObject.GetComponentInParent<Car>();
                if (IsAttackingEnemy)
                    enemyController.Attack(attackedEnemy);
            }
        }

        void OnTriggerExit(Collider collider)
        {
            attackedEnemy = collider.gameObject.GetComponentInParent<Car>();
            enemyController.NotAttack();
        }
    }
}