using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

public class EnemyAttackZone : MonoBehaviour {

	[SerializeField]
	AttackEnemy enemyController;
	Car attackedEnemy;

	internal bool IsAttackingEnemy{
		get {return attackedEnemy != null;}
	}
	void OnTriggerStay(Collider collider) {
		attackedEnemy = collider.gameObject.GetComponentInParent<Car>();
		if(IsAttackingEnemy) enemyController.Attack(attackedEnemy);
	}
	void OnTriggerExit(Collider collider) {
		attackedEnemy = collider.gameObject.GetComponentInParent<Car>();
		enemyController.NotAttack();				
	}
}
