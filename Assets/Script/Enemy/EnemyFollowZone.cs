using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarAdventure.Entity;

public class EnemyFollowZone : MonoBehaviour {
		
	[SerializeField]
	AttackEnemy enemyController;
	[SerializeField]
	Transform destiny;

	Car followedEnemy;

	internal bool IsFollowingEnemy{
		get {return followedEnemy != null;}
	}

	void Start(){
		enemyController.CheckTarget(destiny.position, false);	
	}
	void OnTriggerStay(Collider collider) {
		followedEnemy = collider.gameObject.GetComponentInParent<Car>();
		if(IsFollowingEnemy) enemyController.CheckTarget(followedEnemy.transform.position, true);	
	}
	void OnTriggerExit(Collider collider) {
		followedEnemy = collider.gameObject.GetComponentInParent<Car>();				
		enemyController.CheckTarget(destiny.position, false);	
	}
}
